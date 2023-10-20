using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Infrastructure.Query;
using InfoResource.Application.Data;
using InfoResource.Domain.Model.InfoResource;

namespace InfoResource.Application
{
    public class InfoResourceObjectConversionService
    {
        public static ResourceData ToResourceData(Resource resource)
        {            
            ResourceData item = new ResourceData();
            item.ResourceId = resource.ResourceId.Id;
            item.Name = resource.Name;
            item.Target = resource.Target;
            item.Comment = resource.Comment;
            item.Phone = resource.Phone;
            item.Email = resource.Email;
            item.ResourceTypeData = ToResourceTypeData(resource.ResourceType);

            return item;
        }

        public static ResourceTypeData ToResourceTypeData(ResourceType resourceType)
        {
            ResourceTypeData item = new ResourceTypeData(resourceType.ResourceTypeId.Id, resourceType.Name);           
            return item;
        }
    }
}
