# Power Pong

## Descrição
Power Pong é um jogo inspirado no clássico Pong, desenvolvido em Unity. O jogo apresenta um sistema de pontuação e movimentação dinâmica das raquetes, proporcionando uma experiência divertida e desafiadora.

**Trailer do Jogo:**

[Assista ao trailer de Power Pong](https://www.youtube.com/watch?v=kkbGb9PVLRY)

*Em um mundo onde velocidade e estratégia definem os vencedores.*  
*Dois jogadores. Duas raquetes. Um único objetivo: **DOMINAR A ARENA!***  
*Cada movimento conta. Cada golpe pode mudar o destino da partida.*  
*Mas aqui, não é só sobre reflexos. Poderes especiais podem virar o jogo a qualquer momento!*  
*A velocidade aumenta. A pressão cresce. E apenas os mais rápidos e estratégicos conseguirão alcançar a **VITÓRIA!***  
*Power Pong - Clássico, rápido e agora, ainda mais **PODEROSO!***  
*Disponível agora. Você está pronto para o desafio?*

## Como Jogar
- O objetivo do jogo é marcar pontos ao fazer com que a bola ultrapasse a raquete adversária.
- O primeiro jogador a atingir a pontuação máxima vence a partida.

### Controles
- **Jogador 1**: Utiliza as teclas `W` e `S` para mover a raquete para cima e para baixo.
- **Jogador 2**: Utiliza as teclas `Seta Para Cima` e `Seta Para Baixo` para mover a raquete.

## Estrutura do Projeto
O jogo é composto pelos seguintes scripts principais:

### 1. `Menu.cs`
- Controla a navegação pelo menu principal.
- Opções: iniciar jogo, fechar jogo e ativar/desativar objetos.

### 2. `Contador.cs`
- Atualiza e exibe a pontuação dos jogadores.

### 3. `Jogador.cs`
- Gerencia o nome do jogador e sua pontuação.
- Chama a função de criação da bola ao marcar pontos.

### 4. `MovimentoBola.cs`
- Controla a velocidade e direção da bola.
- Define colisões com raquetes e paredes.

### 5. `MovimentoRaquete.cs`
- Controla a movimentação das raquetes usando `InputActionReference`.

### 6. `Partida.cs`
- Gerencia a criação da bola e exibição do vencedor.

### 7. `TriggerPontos.cs`
- Detecta quando a bola ultrapassa uma das raquetes e adiciona pontos ao jogador correspondente.

## Como Executar o Projeto
1. Certifique-se de ter o Unity instalado.
2. Abra o projeto no Unity.
3. Pressione `Jgar` para iniciar o jogo.

## Requisitos
- **Engine**: Unity
- **Dependências**: `TextMeshPro` para exibição de textos.

## Melhorias Futuras
- Adição de novos mapas.
- Implementação novos efeitos visuais/sonoros.
- Suporte para modos de jogo personalizados.

---

Desenvolvido por [Grupo III]. Divirta-se jogando Power Pong - WASD!
