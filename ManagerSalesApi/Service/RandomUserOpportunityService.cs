using AutoMapper;
using ManagerSalesApi.Client;
using ManagerSalesApi.Client.Response;
using ManagerSalesApi.Controllers.Request;
using ManagerSalesApi.Data;
using ManagerSalesApi.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace ManagerSalesApi.Service
{
    public class RandomUserOpportunityService
    {
        private DataBaseContext _context;
        private PublicaCnpjClient _client;
        private readonly IMapper _mapper;

        public RandomUserOpportunityService(DataBaseContext context, 
            PublicaCnpjClient client, IMapper mapper)
        {
            _context = context;
            _client = client;
            _mapper = mapper;
        }

        public Opportunity GetUserOpportunity(OpportunityRequest opportunityRequest)
        {
            CnpjResponse cnpjResponse = _client.GetInfoByCnpj(opportunityRequest.Cnpj).Result;
            int region = int.Parse(cnpjResponse.Establishment.State.IbgeId.Substring(0, 1));
            List<User> users = _context.Users.Where(f => ((int)f.Region) == region).ToList();

            User userAdd = null;

            if (users.Count > 1)
            {
                users.ForEach(delegate (User user) 
                {
                    List<Opportunity> opportunities = _context.Opportunities.Where(b => b.user.Id == user.Id).ToList();
                    if(opportunities.Count < 1)
                    {
                        userAdd = user;
                    }
                });
                if(userAdd == null)
                {
                    userAdd = users[0];
                }
            }
            else
            {
                if(users.Count == 0)
                {
                    throw new BadHttpRequestException("Nenhum usuário foi encontrado para a região do cnpj!");
                }
                userAdd = users[0];
            }

            Opportunity opportunity = _mapper.Map<Opportunity>(opportunityRequest);
            opportunity.user = userAdd;
            opportunity.CorporateName = cnpjResponse.CorporateName;
            opportunity.TaskMain = cnpjResponse.Establishment.TaskMain.Description;

            _context.Opportunities.Add(opportunity);
            _context.SaveChanges();

            return opportunity;
        }

    }
}
