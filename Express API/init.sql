
CREATE TABLE LoginSignUp (
  Username TEXT,
  Password TEXT NOT NULL,
  Role TEXT NOT NULL,
  PRIMARY KEY(Username)
);
INSERT Into LoginSignUp (Username, Password, Role) VALUES ('oshanoshu','oshan123','admin');
INSERT Into LoginSignUp (Username, Password, Role) VALUES ('pradip','pradip123','user');
INSERT Into LoginSignUp (Username, Password, Role) VALUES ('sudeep','sudeep123','user');
CREATE TABLE Administrators (
  AdminID SERIAL PRIMARY KEY,
  Building TEXT NOT NULL,
  Email TEXT not null,
  Name TEXT NOT NULL,
  phoneNumber TEXT NOT NULL,
  Major TEXT,
  Address TEXT NOT NULL,
  Username Text NOT Null
);
CREATE TABLE Residents (
	ResidentID	SERIAL PRIMARY KEY,
	RoomNumber	INTEGER NOT NULL,
	Building	TEXT NOT NULL,
	EmergencyContact	TEXT,
	Address	TEXT NOT NULL,
	phoneNumber	TEXT NOT NULL,
	Name	TEXT NOT NULL,
	Major	TEXT,
  Username Text NOT Null
);
CREATE TABLE Fines (
  FineID SERIAL,
  fineReason Text NOT NULL,
  fineAmount Text NOT NUll,
  AdmID INTEGER References Administrators(AdminID),
  ResID INTEGER References Residents(ResidentID),
  PRIMARY KEY (FineID,AdmID,ResID)
);

CREATE TABLE EmergencyAlerts(
  EmergencyID SERIAL,
  EmergencyCategory text not null,
  EmergencyMessage text not null,
  AdmID INTEGER References Administrators(AdminID),
  PRIMARY key (EmergencyID,AdmID)
);

CREATE table Guest(
  GuestID Serial,
  GuestName Text not null,
  CheckinTime Text not null,
  ResID INTEGER References Residents(ResidentID),
  PRIMARY key (GuestID,ResID)
);

Create table WorkOrder(
  WorkOrderID Serial,
  WorkOrderMonth text not null,
  WorkOrderItem text not null,
  ResID INTEGER References Residents(ResidentID),
  PRIMARY Key(WorkOrderID,ResID)
);
CREATE TABLE Discussions ( DiscussionId INTEGER NOT NULL,
  Discussiontitle TEXT NOT NULL,
  Discussionbody TEXT NOT NULL,
  Discussiontime TEXT NOT NULL,
  Resid INTEGER References Residents(ResidentID),
  PRIMARY key (DiscussionId,ResID)
);
Create table Comments(
  CommentID Serial,
  CommentBody text not null,
  CommentTime text not null,
  ResID INTEGER not null,
  DisId INTEGER not null,
  Foreign Key(ResID, DisID) References Discussions(ResID, DiscussionId),
  Primary Key(CommentID,ResID, DisID)
);
