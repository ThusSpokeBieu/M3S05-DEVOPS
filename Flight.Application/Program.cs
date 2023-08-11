using Flight.Core;
using Flight.Core.Services;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddSingleton<IVooService, VooService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/app/voos", (IVooService v) => v.GetVoos());

app.Map("app/voos/{nomeDoPassageiro}", (string nomeDoPassageiro, IVooService v) =>
{
    return v.GetPassageiros(nomeDoPassageiro);
});

app.MapPost("/app/voos", (VooDTO dto, IVooService v) =>
{
    v.AdicionaVoo(dto.origem, dto.destino, dto.data, dto.QuantidadePassagem);
    return v.GetVoos();
});

app.MapPost("/app/voos/{vooId}", (int vooId, string nomeDoPassageiro, IVooService v) =>
{
    v.Comprar(vooId, nomeDoPassageiro);
    return v.GetPassageiros(nomeDoPassageiro);
});

app.Run();
