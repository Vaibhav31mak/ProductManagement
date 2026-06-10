global using MediatR;
global using AutoMapper;
global using Microsoft.Extensions.DependencyInjection;
global using FluentValidation;

global using ProductManagement.Application.Features.Products.Command;
global using ProductManagement.Infrastructure.Repositories.Contracts;
global using ProductManagement.Domain.Entities;
global using ProductManagement.Application.DTOs;
global using ProductManagement.Application.ResultPattern;
global using ProductManagement.Application.Features.Products.Validators;
global using ProductManagement.Application.Features.Products.Handlers;
global using ProductManagement.Application.Mappers;