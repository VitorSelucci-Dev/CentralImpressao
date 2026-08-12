Sistema de Etiquetas
Central de impressão de etiquetas com cadastro de produtos, desenvolvida em C# com banco de dados MySQL, pensada para rodar em rede local compartilhada entre múltiplos computadores.

Sobre o projeto
O sistema nasceu da necessidade de agilizar a impressão de etiquetas de produtos, eliminando a redigitação manual de dados a cada impressão. A ideia central é simples: cadastrar o produto uma única vez e, a partir daí, puxar suas informações sempre que for necessário gerar uma nova etiqueta.

Funcionalidades
Cadastro completo de produtos, com os campos:
Código
Referência
Marca
Código de Barras
Nome
Un (UN, JG ou KIT)
Quantidade (para itens do tipo jogo/kit)
Busca de produtos já cadastrados para reaproveitamento em novas impressões
Geração de etiquetas via template (ZPL)
Impressão direta em impressoras térmicas
Banco de dados centralizado, compartilhado entre os computadores da rede

Impressoras suportadas
Impressora Status Linguagem
Zebra ZD220
Argox

Tecnologias
C# (.NET)
MySQL — banco de dados relacional compartilhado em rede
ZPL (Zebra Programming Language) — geração dos layouts de etiqueta

Arquitetura
Aplicação desktop (executável) instalada em cada computador da rede
Banco de dados MySQL centralizado, acessado remotamente pelos clientes
Templates de etiqueta armazenados no banco, permitindo múltiplos modelos por impressora/tipo de produto
Impressão via envio direto de comandos ZPL para a impressora (USB ou rede)

Roadmap
Modelagem do banco de dados (tabela de produtos)
Tela de cadastro de produtos (CRUD)
Tela de impressão com modelo único de etiqueta
Integração com impressora Zebra ZD220 via ZPL
Empacotamento como executável distribuível em rede
Suporte a múltiplos modelos de etiqueta (central de impressão)
Suporte à impressora Argox

Status
Em desenvolvimento inicial.

Licença
Este projeto está sob a licença MIT.
