﻿using InterRapiStudy.Context;
using InterRapiStudy.Mappers;
using InterRapiStudy.Services;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Dtos;

public class ProgramService(InterRapiStudyDbContext context) : IProgramService
{
    private readonly ProgramStudyMapper _mapper = new();

    public async Task<IEnumerable<FindProgramStudyDto>> FindPrograms()
    {
        return await context.ProgramStudies.Select(p => _mapper.ProgramToProgramDto(p)).ToListAsync();
    }

    public async Task CreateProgram(CreateProgramStudyDto createProgramStudyDto)
    {
        var program = _mapper.ProgramDtoToProgram(createProgramStudyDto);
        await context.ProgramStudies.AddAsync(program);
        await context.SaveChangesAsync();
    }
}