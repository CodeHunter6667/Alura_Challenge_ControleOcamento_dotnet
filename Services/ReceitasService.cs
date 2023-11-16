using AutoMapper;
using Challenge_2.Context;
using Challenge_2.DTOs;
using Challenge_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge_2.Services;

public class ReceitasService
{
    private readonly IMapper _mapper;
    public AppDbContext _context;
    

    public ReceitasService(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReceitasDTO> GetById(int id){
        var entity = await _context.Receitas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        var receitaDto = _mapper.Map<ReceitasDTO>(entity);
        return receitaDto;
    }

    public async Task<IEnumerable<ReceitasDTO>> GetAll()
    {
        var receitas = _context.Receitas.Skip(0).Take(5).AsNoTracking();
        var receitasDto = _mapper.Map<List<ReceitasDTO>>(receitas);
        return receitasDto;
    }

    public async Task<ReceitasDTO> Post(ReceitasDTO dto)
    {
        Receitas receita = new();
        copyDtoToEntity(dto, receita);
        
        _context.Receitas.Add(receita);
        await _context.SaveChangesAsync();
        return dto;
    }

    public async Task<Receitas> Put(ReceitasDTO dto)
    {
        var receita = new Receitas();
        copyDtoToEntity(dto, receita);
        _context.Entry(receita).State = EntityState.Modified;
        _context.Receitas.Update(receita);
        await _context.SaveChangesAsync();
        return receita;
    }

    public void Delete(ReceitasDTO dto)
    {
        var receita = new Receitas();
        copyDtoToEntity(dto, receita);
        _context.Remove(receita);
        _context.SaveChanges();
    }

    private static void copyDtoToEntity(ReceitasDTO dto, Receitas entity)
    {
        entity.Id = dto.Id;
        entity.Descricao = dto.Descricao;
        entity.Valor = dto.Valor;
        entity.Data = dto.Data;
    }
}