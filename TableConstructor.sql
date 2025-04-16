CREATE TABLE servicebrokerTask (
	ID int NOT NULL,
	TimeCreated DateTime NOT NULL,
	TaskType int,
	TaskDataRef int, 
	TaskDataType int
	
	Primary Key (ID)
);

CREATE TABLE serviceBrokerTodo (
	ID int NOT NULL,
	TaskID int NOT NULL,
	TimeScheduled DateTime NOT NULL,
	primary key (ID)
);

CREATE TABLE serverBrokerDoing (
	ID int NOT NULL,
	TaskID int NOT NULL,
	TimeStarted DateTime NOT NULL,
	primary key (ID)
);

CREATE TABLE serverBrokerDone (
	ID int NOT NULL,
	TaskID int NOT NULL,
	TimeCompleted DateTime NOT NULL,
	primary key (ID)
);

CREATE TABLE Pizza (
	ID int NOT NULL,
	Topping int NOT NULL,
	primary key (ID)
);

