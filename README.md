# Advanced Business Developmente With .Net - GS

# SolarTracker <img src="Images/solartracker.png" alt="SolarTracker" width="35" height="35" /> 

˖°☀️💡 ***Ilumine com energia solar e faça a diferença para o planeta.*** <img width="30" height="30" src="https://img.icons8.com/external-nawicon-flat-nawicon/64/external-solar-panel-energy-nawicon-flat-nawicon-2.png" alt="external-solar-panel-energy-nawicon-flat-nawicon-2"/> ࿐࿔

<br>

# Integrantes
    RM: 551401  Turma: 2TDSPF  Nome: Ana Luiza Fontes 
    RM: 86293   Turma: 2TDSA   Nome: João Vito
    RM: 550128  Turma: 2TDSA   Nome: Marco Antônio
    RM: 552408  Turma: 2TDSA   Nome: Leonardo Bruno
    RM: 99343   Turma: 2TDSA   Nome: Vinicius Andrade

<br>

# Sobre o Projeto
SolarTracker é a plataforma digital que te coloca no controle da sua energia solar, oferecendo monitoramento em tempo real para quem já possui placas solares, revelando como pode economizar e contribuir para um desenvolvimento mais sustentável através de gráficos durante os meses. Já para pessoas que ainda não possuem placas solares, terá cálculos personalizados de acordo com o consumo de kW mensal, comparando o custo da energia costumeira com a economia que você terá com placas solares e ajudar na transição para um futuro mais sustentável.

<br>


# Design pattern em .Net

Como design pattern decidimos escolher o de Injeção de depencias deixando a aplicação mais flexivel e facil para escalar. Criamos as interfaces e repositories e configuramos na program.cs 

![image](https://github.com/user-attachments/assets/8dd3597b-9778-4f4f-bee0-66526e7a3244)

![image](https://github.com/user-attachments/assets/39d3467a-1196-4227-9eb2-9fd3a4b939c9)

<br>


# Docunmentação de testes automatizados de  APIs 

Para a documentação baixamos as dependencias do swagger e o configuramos na program.cs. Se atente na documentação dos endpoints para um entendimento melhor, certas classes possuem propriedades que são Enums então se atente nos EndPoints de post.
![image](https://github.com/user-attachments/assets/95b2e342-2ed5-475f-912c-f7a529c16191)

Segue exemplo de um EndPoint no qual usamos Enum para cadastrar como ativo ou desativo
![image](https://github.com/user-attachments/assets/7cfdd5d5-1e39-4705-806b-73676b09fa36)

## Testes automatizados da API
Utilizando o Xunit e moq realizamos testes na API para os metodos de estabelecimentos, usuarios, placa solares e registros da placa
![image](https://github.com/user-attachments/assets/fab8f8ac-4133-450f-8da7-0b6b88e7f304)


Exemplo de um teste que verifica o metodo get do estabelecimentos 
![image](https://github.com/user-attachments/assets/bc31ed8e-704e-47fb-baab-f716250acd21)


<br>


# Banco de dados

Para o banco de dados utilizamos o Oracle aonde configuramos no Appsettings.Json e criamos no DbContext propriedades publicas das classes

![image](https://github.com/user-attachments/assets/6ad9ce35-5a97-48fb-a4a1-037a785a2a13)



