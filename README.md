# consultaInsercaoDeDadosComApiIBGE
 Implementar uma API C# que irá fazer onboarding e algumas consultas de novos clientes. 

EXPLICAÇÃO RESUMIDA:

#Modelos para o banco de dados SQL Server:
- Cliente
- Gestor
- Plano VIP

#Update para o banco através de migrations

#Management Studio para melhor visualização e facilidade nas consultas

#Doc TXT com as queries

# Controler com métodos básicos de CRUD
# Interface de Repositório base e implementação em repositórios específicos, respeitando conceitos de SOLID

#criacao de classe data context para injeção dos modelos e conexão com banco

#Em compartilhado:
- Classe validadora de CPF
- Modelo de Plano Vip
- Classe para PosCadastro de clientes, diminuindo a carga de código

#Dominio para insercao de planos vips

-----------------------------------

Obs: 
1) testes realizados no postman;
2) o modelo ideal seria criar dominios para ter uma camada entre controllers e repositorio e serviços para lidar com mais de um dominio e/ou regras de negocio






