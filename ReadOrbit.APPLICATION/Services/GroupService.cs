using ReadOrbit.APPLICATION.DTOs.GroupDtos;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Services
{
    public class GroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<int> CreateGroupAsync(CreateGroupDTO createGroupDTO)
        {
            if (createGroupDTO == null) return 0;

            var group = new Group
            {
                Id = createGroupDTO.Id,
                Name = createGroupDTO.Name,
                Description = createGroupDTO.Description
            };

            return await _groupRepository.AddNewGroupAsync(group);
        }
        public async Task<GetGroupDTO> GetGroupByIdAsync(string groupId)
        {
            var group = await _groupRepository.GetGroupByIdAsync(groupId);
            var groupDto = new GetGroupDTO
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description
            };
            return groupDto;
        }
        public async Task<IEnumerable<GetGroupDTO>> GetAllGroupsAsync()
        {
            var groups = await _groupRepository.GetGroupsAsync();
            return groups.Select(g => new GetGroupDTO
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description
            }).ToList();
        }
        public async Task<int> UpdateGroupAsync(CreateGroupDTO updateGroupDTO)
        {
            if (updateGroupDTO == null) return 0;

           var existingGroup = await _groupRepository.GetGroupByIdAsync(updateGroupDTO.Id);

            if (existingGroup == null) return 0;
           
            if(updateGroupDTO.Name != null)
            {
                existingGroup.Name = updateGroupDTO.Name;
            }
            if (existingGroup.Name != null)
            {
                existingGroup.Description = updateGroupDTO.Description;
            }

            var updatedGroup = await _groupRepository.UpdateGroupAsync(existingGroup);
            return updatedGroup;
        }
        
    }
}
