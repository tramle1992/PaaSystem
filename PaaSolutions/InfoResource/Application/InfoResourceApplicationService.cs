using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoResource.Infrastructure.InfoResource;
using InfoResource.Domain.Model.InfoResource;
using InfoResource.Application.Command;
using InfoResource.Application.Data;
using Common.Domain.Model;

namespace InfoResource.Application
{
    public class InfoResourceApplicationService
    {
        public InfoResourceApplicationService()
            : this (new ResourceTypeRepository(), new InfoResourceRepository())
        {

        }

        public InfoResourceApplicationService(ResourceTypeRepository resourceTypeRepository, InfoResourceRepository resourceRepository)
        {
            this.resourceTypeRepository = resourceTypeRepository;
            this.resourceRepository = resourceRepository;
        }

        readonly ResourceTypeRepository resourceTypeRepository;
        readonly InfoResourceRepository resourceRepository;

        public void ChangeResource(ChangeResourceCommand command)
        {
            ResourceType resourceType = resourceTypeRepository.Find(command.ResourceTypeId);
            if (resourceType == null)
                throw new ArgumentException("ResourceType with Id={0} does not exist.", command.ResourceTypeId.ToString());
            Resource resouce = resourceRepository.Find(command.ResourceId);
            if (resouce == null)
                throw new ArgumentException("Resource with Id={0} does not exist.", command.ResourceId.ToString());
            resouce.ChangeResource(command.Name, command.Target, command.Comment, command.Phone, command.Email, resourceType);
        }

        public void ChangeResourceName(string resourceId, string resourceName)
        {            
            Resource resource = resourceRepository.Find(resourceId);
            if (resource == null)
                throw new ArgumentException("Resource with Id={0} does not exist.", resourceId.ToString());
            resource.ChangeResource(resourceName, resource.Target, resource.Comment, resource.Phone, resource.Email, resource.ResourceType);
        }

        public void ChangeResourceTarget(string resourceId, string resourceTarget)
        {            
            Resource resource = resourceRepository.Find(resourceId);
            if (resource == null)
                throw new ArgumentException("Resource with Id={0} does not exist.", resourceId.ToString());
            resource.ChangeResource(resource.Name, resourceTarget, resource.Comment, resource.Phone, resource.Email, resource.ResourceType);
        }

        public void ChangeResourceComment(string resourceId, string resourceComment)
        {            
            Resource resource = resourceRepository.Find(resourceId);
            if (resource == null)
                throw new ArgumentException("Resource with Id={0} does not exist.", resourceId.ToString());
            resource.ChangeResource(resource.Name, resource.Target, resourceComment, resource.Phone, resource.Email, resource.ResourceType);
        }

        public void ChangeResourceType(ChangeResourceTypeCommand command)
        {
            ResourceType resourceType = resourceTypeRepository.Find(command.ResourceTypeId);
            if (resourceType == null)
                throw new ArgumentException("ResourceType with Id={0} does not exist.", command.ResourceTypeId.ToString());
            resourceType.ChangeName(command.Name);
        }

        public void When(MoveResourceToResourceTypeCommand command)
        {
            ResourceType resourceType = resourceTypeRepository.Find(command.ResourceTypeId);
            if (resourceType == null)
                throw new ArgumentException("ResourceType with Id={0} does not exist.", command.ResourceTypeId);
            Resource resource = resourceRepository.Find(command.ResourceId);
            if (resource == null)
                throw new ArgumentException("Resource with Id={0} does not exist.", command.ResourceId);
            resource.ChangeResource(resource.Name, resource.Target, resource.Comment, resource.Phone, resource.Email, resourceType);
        }

        public void MoveResourceToResourceType(string resourceId, string resourceTypeId)
        {
            ResourceType resourceType = resourceTypeRepository.Find(resourceTypeId);
            if (resourceType == null)
                throw new ArgumentException("ResourceType with Id={0} does not exist.", resourceId.ToString());
            Resource resource = resourceRepository.Find(resourceId);
            if (resource == null)
                throw new ArgumentException("Resource with Id={0} does not exist.", resourceId.ToString());
            resource.ChangeResource(resource.Name, resource.Target, resource.Comment, resource.Phone, resource.Email, resourceType);
        }

        public string NewResourceType(NewResourceTypeCommand command)
        {
            ResourceTypeId id = new ResourceTypeId(Guid.NewGuid().ToString());
            ResourceType resourceType = new ResourceType(id, command.Name);
            resourceTypeRepository.Add(resourceType);
            return resourceType.ResourceTypeId.Id;
        }

        public void SaveResourceType(SaveResourceTypeCommand command)
        {
            ResourceType resourceType = resourceTypeRepository.Find(command.ResourceTypeId);
            resourceType.Name = command.ResourceTypeName;            
            resourceTypeRepository.Update(resourceType);
        }

        public string NewResource(NewResourceCommand command)
        {
            ResourceId id = new ResourceId(Guid.NewGuid().ToString());
            ResourceType resourceType = resourceTypeRepository.Find(command.ResourceTypeId);
            Resource resource = new Resource(id, command.Name, command.Target, command.Comment, command.Phone, command.Email, resourceType);
            resourceRepository.Add(resource);
            return resource.ResourceId.Id;
        }

        public void SaveResource(SaveResourceCommand command)
        {
            Resource resource = resourceRepository.Find(command.ResourceId);
            ResourceType resourceType = new ResourceType(
                new ResourceTypeId(command.ResourceData.ResourceTypeData.ResourceTypeId),
                command.ResourceData.ResourceTypeData.Name);
            resource.Name = command.ResourceData.Name;
            resource.Target = command.ResourceData.Target;
            resource.Comment = command.ResourceData.Comment;
            resource.Phone = command.ResourceData.Phone;
            resource.Email = command.ResourceData.Email;
            resource.ResourceType = resourceType;
            resourceRepository.Update(resource);
        }

        public void DeleteResource(string id)
        {
            resourceRepository.Remove(id);
        }

    }
}
