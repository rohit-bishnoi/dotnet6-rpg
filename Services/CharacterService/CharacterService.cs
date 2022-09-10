using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterService;

public class CharacterService : ICharacterService
{

    private static List<Character> characters = new List<Character>() {
        new Character(),
        new Character { Id=1, Name = "Sam"}
    };

    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var servicesResponse = new ServiceResponse<List<GetCharacterDto>>();
        Character character = _mapper.Map<Character>(newCharacter);
        character.Id = characters.Max(c => c.Id) + 1;
        characters.Add(character);
        servicesResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return servicesResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
        ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
        try
        {

            Character character = characters.First(c => c.Id == id);

            characters.Remove(character); 

            response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        return new ServiceResponse<List<GetCharacterDto>>
        {
            Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
        };
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var servicesResponse = new ServiceResponse<GetCharacterDto>();
        var character = characters.FirstOrDefault(c => c.Id == id);
        servicesResponse.Data = _mapper.Map<GetCharacterDto>(character);
        return servicesResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
        try
        {

            Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

            _mapper.Map(updatedCharacter, character);

            // character.Name = updatedCharacter.Name;
            // character.HitPoint = updatedCharacter.HitPoint;
            // character.Strength = updatedCharacter.Strength;
            // character.Defense = updatedCharacter.Defense;
            // character.Intelligence = updatedCharacter.Intelligence;

            // character.Class = updatedCharacter.Class;

            response.Data = _mapper.Map<GetCharacterDto>(character);

        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}
