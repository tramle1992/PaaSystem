using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Infrastructure.Query;
using InfoResource.Application.Data;
using InfoResource.Infrastructure.InfoResource;
using InfoResource.Domain.Model.InfoResource;

namespace InfoResource.Application
{
    public class InfoResourceQueryService
    {
        readonly InfoResourceRepository resourceRepository;
        readonly ResourceTypeRepository resourceTypeRepository;

        public InfoResourceQueryService()
        {
            resourceRepository = new InfoResourceRepository();
            resourceTypeRepository = new ResourceTypeRepository();
        }

        public IList<ResourceTypeData> GetAllResourceType()
        {
            List<ResourceTypeData> lstResult = new List<ResourceTypeData>();
            IEnumerable<ResourceType> resourceTypes = resourceTypeRepository.FindAll();
            foreach (ResourceType resourceType in resourceTypes)
            {
                lstResult.Add(InfoResourceObjectConversionService.ToResourceTypeData(resourceType));
            }
            return lstResult;
        }

        public ResourceTypeData GetResourceType(string id)
        {
            ResourceType resourceType = resourceTypeRepository.Find(id);
            if (resourceType == null)
            {
                return null;
            }
            return InfoResourceObjectConversionService.ToResourceTypeData(resourceType);
        }

        public IList<ResourceData> GetAllResource()
        {
            List<ResourceData> lstResult = new List<ResourceData>();
            IEnumerable<Resource> resources = resourceRepository.FindAll();
            foreach (Resource resource in resources)
            {
                lstResult.Add(InfoResourceObjectConversionService.ToResourceData(resource));
            }
            return lstResult;
        }

        public ResourceData GetResource(string id)
        {
            Resource resource = resourceRepository.Find(id);
            if (resource == null)
            {
                return null;
            }
            return InfoResourceObjectConversionService.ToResourceData(resource);
        }

    }
}
