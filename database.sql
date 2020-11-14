--CREATE DATABASE ProposalManagement;
--GO

use [ProposalManagement];
GO

CREATE TABLE [Status]
(
  [StatusId]  [int] IDENTITY (1, 1),
  [Name] varchar(30) NOT NULL
  CONSTRAINT PK_Status_Id PRIMARY KEY ([StatusId]),
);
GO 

INSERT INTO [Status] ([Name]) 
VALUES
('Draft'),
('Sent'),
('Approved'),
('Denied')
GO

CREATE TABLE [Role]
(
  [RoleId] [int] IDENTITY (1, 1),
  [Name] varchar(30) NOT NULL
  CONSTRAINT PK_Role_Id PRIMARY KEY ([RoleId]),
);
GO 

INSERT INTO [Role] ([Name]) 
VALUES
('Admin'),
('Client'),
('Submitter')
GO

CREATE TABLE BudgetTemplate
(
  [BudgetTemplateId]  [int] IDENTITY (1, 1),
  [Name] varchar(30) NOT NULL,
  [Amount] [float] NULL,
  [Enabled] [bit] NULL,
  CONSTRAINT PK_BudgetTemplate_Id PRIMARY KEY ([BudgetTemplateId]),
);
GO 

CREATE TABLE Budget
(
  [BudgetId] [int] IDENTITY (1, 1),
  [Name] varchar(30) NOT NULL,
  [Amount] [float] NULL,
  [RemainingAmount] [float] NULL,
  [BudgetTemplateId] [int] NULL,
  [Enabled] [bit] NULL,
  CONSTRAINT PK_Budget_Id PRIMARY KEY ([BudgetId]),
  CONSTRAINT FK_Budget_To_BudgetTemplate FOREIGN KEY([BudgetTemplateId]) REFERENCES BudgetTemplate ([BudgetTemplateId])
);
GO 

CREATE TABLE [User]
(
  [UserId] [int] IDENTITY (1, 1),
  [Name] varchar(30) NULL,
  [Surname] varchar(30) NULL,
  [Password] varchar(30) NULL,
  [Email] varchar(30) NULL,
  [RoleId] [int] NULL,
  CONSTRAINT PK_User_Id PRIMARY KEY ([UserId]),
  CONSTRAINT FK_User_To_Role FOREIGN KEY([RoleId]) REFERENCES [Role] ([RoleId])
);
GO 

CREATE TABLE [Proposal]
(
  [ProposalId] [int] IDENTITY (1, 1),
  [Name] varchar(30) NULL,
  [Purpose] varchar(30) NULL,
  [Amount] [float] NULL,
  [BankAccount] varchar(30) NULL,
  [StatusId] [int] NULL,
  [UserId] [int] NULL,
  CONSTRAINT PK_Proposal_Id PRIMARY KEY ([ProposalId]),
  CONSTRAINT FK_Proposal_To_Status FOREIGN KEY([StatusId]) REFERENCES [Status] ([StatusId]),
  CONSTRAINT FK_Proposal_To_User FOREIGN KEY([UserId]) REFERENCES [User] ([UserId])
);
GO 

CREATE TABLE Payment
(
  [PaymentId] [int] IDENTITY (1, 1),
  [Name] varchar(30) NULL,
  [Amount] [float] NULL,
  [ProposalId] [int] NULL,
  [BudgetId] [int] NULL,
  CONSTRAINT PK_Payment_Id PRIMARY KEY ([PaymentId]),
  CONSTRAINT FK_Payment_To_Proposal FOREIGN KEY([ProposalId]) REFERENCES Proposal ([ProposalId]),
  CONSTRAINT FK_Payment_To_Budget FOREIGN KEY([BudgetId]) REFERENCES Budget ([BudgetId])
);
GO 