<h1 align="center">
  <br>
  Teste SignalR – Fila Hospital
  <br>
</h1>

<h4 align="center">
  Demonstração simples em ASP.NET Core + SignalR para chamar senhas como em atendimentos de hospitais e cartórios em tempo real.
</h4>

<p align="center">
  <a href="#sobre">Sobre</a> -
  <a href="#recursos">Recursos</a> -
  <a href="#executar-localmente">Executar localmente</a> -
  <a href="#como-funciona">Como funciona</a> -
  <a href="#todo">TODO</a> -
</p>

## Sobre
O projeto foi criado para eu aprender mais sobre o **SignaR** que é uma biblioteca feita para facilitar o desenvolvimento de aplicações que usam **WebSocket**, com isso surgiu a ideia de projeto de chamador de senhas entre dispositivos. Com esse aprendizado pretendo criar uma aplicação profissional focada no atendimento via Tickets.

Lembrando que o projeto está **publicado gratuitamente** em produção no **Render.com** usando a imagem Docker criada. Abra o link abaixo no computador e no celular ao mesmo tempo e verá as senhas serem chamadas em tempo real.

Acesse: <https://sinalr.onrender.com/> `Caso demore espere um pouco para o Render ligar a aplicação novamente`

## Recursos
- **Broadcast em tempo real** – todos os clientes recebem a nova senha instantaneamente via SignalR.
- **Botão “Chamar próxima”** – incrementa o número e atualiza a tela de todos. 
- **Front‑end mínimo** – página Razor com título *Fila Hospital* e contador de senha.

## Executar localmente
```bash
git clone https://github.com/Matozo0/TesteSignalR.git
cd TesteSignalR
dotnet restore
dotnet run                 # app em https://localhost:5001
````
Também há um **Dockerfile**; rode `docker build -t teste-signalr . && docker run -p 5000:80 teste-signalr`.

## Como funciona

1. O **TicketHub** mantém um campo estático `_senhaAtual` e expõe dois métodos:

   * `ChamarProximaSenha()` – incrementa e envia para todos os clientes.
   * `ObterSenhaAtual()` – envia a senha atual para quem acabou de conectar. 
2. No `Program.cs`, o hub é registrado em `/ticketHub` e as Razor Pages são habilitadas.
3. No front‑end, JavaScript cria uma conexão SignalR, escuta `SenhaAtualizada` e atualiza o DOM. Lembrando já que é o JavaScript que cria a conexão, ela pode ser conectada/criada em qualquer site, só precisando importar o CDN do SignalR e configurar para o Hub no .NET .

## TODO
* [ ] Melhorar layout (CSS)
* [ ] Testes unitários do hub
* [ ] Deploy automático via GitHub Actions