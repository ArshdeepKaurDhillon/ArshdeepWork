
create database ClubBaistGCMS

use ClubBaistGCMS

CREATE TABLE DailyTeeSheet(
Date date NOT NULL PRIMARY KEY)

insert into DailyTeeSheet(Date) VALUES('2020-5-5')
drop table TeeTime

cREATE TABLE TeeTime(
Date date Not Null , 
Time time Not Null, 
NumberOfCarts int , 
NumberOfPlayers int Not Null,
PlayerFirstName varchar(10) Not Null, 
PlayerLastName varchar(10) Not Null,
Phone varchar(15),
Primary key(Date,Time)
)

SELECT * FROM TeeTime

INSERT INTO TeeTime(Date,Time,NumberOfCarts,NumberOfPlayers,PlayerFirstName,PlayerLastName) 
values('2020-5-3','6:00 pm',1,1,'Aman','Vashisht')


alter table TeeTime add constraint FK_Date 
Foreign Key(Date) 
references DailyTeeSheet(Date)

create table Player(
PlayerFirstName varchar(10) Not Null , 
PlayerLastName varchar(10) Not null  , 
PhoneNumber varchar(10) Not Null,
primary key(PlayerFirstName, PlayerLastName))

insert into Player(PlayerFirstName,PlayerLastName,PhoneNumber) values('Aman','Vashisht','9898330101')

alter table TeeTime add constraint FK1
Foreign Key(PlayerFirstName,PlayerLastName) 
references Player(PlayerFirstName,PlayerLastName)

select * from TeeTime

create table StandingTeeTimeRequest(
MemberNumber int Not Null, 
MemberFirstName varchar(10) Not Null, 
MemberLastName varchar(10) Not Null,
DayOfWeek int check (DayOfWeek > 0 and DayOfWeek <8),
RequestedTeeTime time NOT NULL, 
RequestedStartDate date NOT NULL, 
RequestedEndDate date NOT NULL)

Alter table StandingTeeTimeRequest Add Constraint pk_Standing Primary Key (MemberNumber)


SELECT * FROM StandingTeeTimeRequest

insert into StandingTeeTimeRequest
(MemberNumber,
MemberFirstName,
MemberLastName,
DayOfWeek,
RequestedTeeTime,
RequestedStartDate,
RequestedEndDate) values(11,'Aman','Vashisht',1,'8 am','2020-5-4','2020-5-4')


create procedure AddTeeTime
(@Date date = NULL,
@Time time = NULL,
@NumberOfCarts int = NULL,
@NumberOfPlayers int = NULL,
@PlayerFirstName varchar(10) = NULL,
@PlayerLastName varchar(10) = NULL,
@Phone varchar(10) = NULL
)
AS 
	DECLARE @ReturnCode iNT
	SET @ReturnCode = 1

	If @Date = NULL
		RAISERROR('Procedure AddTeeTime: Add Date Parameter',16,1)
	ELSE IF @Time = NULL
		RAISERROR('Procedure AddTeeTime: Add Time Parameter',16,1)
	ELSE IF @NumberOfPlayers = NULL
		RAISERROR('Procedure AddTeeTime: Add NumberOfPlayers Parameter',16,1)
	ELSE IF @PlayerFirstName = NULL
		RAISERROR('Procedure AddTeeTime: Add PlayerFirstName Parameter',16,1)
	ELSE IF @PlayerLastName = NULL
		RAISERROR('Procedure AddTeeTime: Add PlayerLastName Parameter',16,1)

	Else
	
	BEGIN
		INSERT INTO TeeTime
		(Date,Time,NumberOfCarts,NumberOfPlayers,PlayerFirstName,PlayerLastName,Phone) 
		VALUES(@Date,@Time,@NumberOfCarts,@NumberOfPlayers,@PlayerFirstName,@PlayerLastName,@Phone)

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

Execute AddTeeTime "2020-5-2", "1 pm",1,1,"Aman","Vashisht",'7808912345'


create procedure GetTeeSheet(@Date date  = NULL)
AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	IF @Date = NULL
	RAISERROR('Procedure: GetTeeSheet- Add Date Parameter',16,1)

	else

	BEGIN
	SELECT * FROM TeeTime WHERE Date = @Date
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

Execute GetTeeSheet "2020-5-2"


create procedure GetTeeTime(
@Date date  = NULL,
@Time time = NULL)
AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	IF @Date = NULL
	RAISERROR('Procedure: GetTeeTime:- Add Date Parameter',16,1)

	ELSE IF @Time = NULL
		RAISERROR('Procedure GetTeeTime: Add Time Parameter',16,1)

	else

	BEGIN
	SELECT * FROM TeeTime WHERE Date = @Date and Time=@Time
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

select * from TeeTime

execute GetTeeTime "2020-05-02","1:00 pm"

DROP PROCEDURE ModifyTeeTime


create procedure UpdateTeeTime
(@Date date = NULL,
@Time time = NULL,
@PlayerFirstName varchar(10) = NULL,
@PlayerLastName varchar(10) = NULL,
@Phone varchar(10) = NULL
)
AS 
	DECLARE @ReturnCode iNT
	SET @ReturnCode = 1

	If @Date = NULL
		RAISERROR('Procedure ModifyTeeTime: Add Date Parameter',16,1)
	ELSE IF @Time = NULL
		RAISERROR('Procedure ModifyTeeTime: Add Time Parameter',16,1)
	ELSE IF @PlayerFirstName = NULL
		RAISERROR('Procedure ModifyTeeTime: Add PlayerFirstName Parameter',16,1)
	ELSE IF @PlayerLastName= NULL
		RAISERROR('Procedure ModifyTeeTime: Add Time Parameter',16,1)
	ELSE IF @Phone = NULL
		RAISERROR('Procedure ModifyTeeTime:Add Phone Parameter',16,1)
	Else
	
	BEGIN
		Update TeeTime set 		 
		PlayerFirstName=@PlayerFirstName,
		PlayerLastName=@PlayerLastName,
		Phone=@Phone
		where Date=@Date and 
		Time=@Time
		

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

Execute ModifyTeeTime "2020-05-02","13:00","Arsh","Dhillon","7808023434"



select * from Player
select * from TeeTime


create procedure AddStandingTeeTime
(@MemberNumber int = NULL,@MemberFirstName varchar(10) = NULL, @MemberLastName varchar(10) = NULL,@DayOfWeek int = NULL,
@RequestedTeeTime time = NULL, @RequestedStartDate date = NULL, @RequestedEndDate date = NULL)
AS
	DECLARE @ReturnCode int
	SET @ReturnCode = 1

	IF @MemberNumber  = null
	RAISERROR('Procedure: AddStandingTeeTime- Add Parameter MemberNumber',16,1)

	ELSE IF @MemberFirstName = null
	RAISERROR('Procedure: AddStandingTeeTime- Add Parameter MemberFirstName',16,1)

	ELSE IF @MemberLastName = null
	RAISERROR('Procedure: AddStandingTeeTime- Add Parameter MemberLastName',16,1)

	ELSE IF @RequestedTeeTime = null
	RAISERROR('Procedure: AddStandingTeeTime- Add Parameter RequestedTeeTime',16,1)

	ELSE IF @RequestedStartDate = null
	RAISERROR('Procedure: AddStandingTeeTime- Add Parameter RequestedStartDate',16,1)

	ELSE IF @RequestedEndDate = null
	RAISERROR('Procedure: AddStandingTeeTime- Add Parameter RequestedEndDate',16,1)

	ELSE 
	BEGIN
		INSERT INTO StandingTeeTimeRequest
		(MemberNumber,MemberFirstName,MemberLastName,DayOfWeek,RequestedTeeTime,RequestedStartDate,RequestedEndDate)
		VALUES
		(@MemberNumber,@MemberFirstName,@MemberLastName,@DayOfWeek,@RequestedTeeTime,@RequestedStartDate,@RequestedEndDate)

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

EXECUTE AddStandingTeeTime 13,"David","Rose",1,"3 pm","2020-6-7","2020-6-7"

select * from StandingTeeTimeRequest

create procedure GetStandingTeeTime(@RequestedStartDate date  = NULL)
AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	IF @RequestedStartDate = NULL
	RAISERROR('Procedure: GetStandingTeeTime- Add RequestedStartDate Parameter',16,1)

	else

	BEGIN
	SELECT * FROM StandingTeeTimeRequest WHERE RequestedStartDate = @RequestedStartDate
			
	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN SELECT',16,1)

	END

RETURN @ReturnCode

EXECUTE GetStandingTeeTime "2020-6-7"



create procedure SearchStandingTeeTime(@MemberNumber int  = NULL)
AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	IF @MemberNumber = NULL
	RAISERROR('Procedure: SearchStandingTeeTime- Add MemberNumber Parameter',16,1)

	else

	BEGIN
	SELECT * FROM StandingTeeTimeRequest WHERE MemberNumber = @MemberNumber
			
	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN SELECT',16,1)

	END

RETURN @ReturnCode


EXECUTE SearchStandingTeeTime 11


create procedure DeleteStandingTeeTimeRequest(@MemberNumber int  = NULL)
AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	IF @MemberNumber = NULL
	RAISERROR('Procedure: DeleteStandingTeeTimeRequest- Add MemberNumber Parameter',16,1)

	else

	BEGIN
	Delete FROM StandingTeeTimeRequest WHERE MemberNumber = @MemberNumber
			
	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN SELECT',16,1)

	END

RETURN @ReturnCode


execute DeleteStandingTeeTimeRequest 11

create procedure InsertPlayer(@PlayerFirstName varchar(10) = Null,
							@PlayerLastName varchar(10)= Null,
							@PhoneNumber varchar(10) = Null)
as
DECLARE @ReturnCode Int
SET @ReturnCode = 1

IF @PlayerFirstName = null
	RAISERROR('Procedure: Insert Player, Parameter PlayerFirstName',16,1)

ELSE IF @PlayerLastName = null
	RAISERROR('Procedure: Insert Player, Parameter PlayerFirstName',16,1)

ELSE IF @PhoneNumber = NULL
	RAISERROR('Procedure: Insert Player, Parameter Phone',16,1)

else

BEGIN

INSERT INTO Player(PlayerFirstName,PlayerLastName,PhoneNumber) values(@PlayerFirstName,@PlayerLastName,@PhoneNumber)

IF @@ERROR = 0
	SET @ReturnCode  = 0

	else
	
	RAISERROR('Error in Insert',16,1)
END

Return @ReturnCode

execute InsertPlayer "Gurfateh","Dhillon","7890987654"

create procedure InsertDate(@Date date = NULL)
AS
DECLARE @ReturnCode Int
SET @ReturnCode = 1

if @Date = Null
	RAISERROR('Procedure:Insert Date, Parameter: Date Required',16,1)

ELSE
BEGIN 

Insert into  DailyTeeSheet(Date) values(@Date)

IF @@Error = 0
	SET @ReturnCode = 0

ELSE

RAISERROR('Error in Insert, Procedure:Insert Date',16,1)
end

Return @ReturnCode

execute InsertDate "2020-05-05"



select * from DailyTeeSheet
select * from player
select * from StandingTeeTimeRequest
select Phone from TeeTime
DELETE FROM TeeTime

select * from MembershipApplication

Create table MembershipApplication(
MemberApplicationNumber int IDENTITY(1,1) Primary key,
FirstName varchar(15),
LastName varchar(15),
Address varchar(20),
PostalCode varchar(6),
Phone varchar(10),
Email varchar(20),
DateOfBirth date,
Occupation varchar(15),
CompanyName varchar(15),
CompanyAddress varchar(15),
CompanyPostalCode varchar(6),
CompanyPhone varchar(10),
ShareholderName varchar(30),
Date date,
Status varchar(15) CHECK(Status='Accepted' or Status='Denied' or Status='On-hold' or Status='Waitlisted'))

DROP PROCEDURE GetMembershipApplications

create procedure GetMembershipApplications
(@Status varchar(15)=NULL)
AS
	DECLARE @ReturnCode Int
	SET @ReturnCode = 1

	IF @STATUS =NULL
	RAISERROR('Procedure GetMembershipApplications: Parameter: Status is missing',16,1)

	else
	BEGIN
	SELECT * FROM MembershipApplication where Status=@Status

	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN SELECT',16,1)

	END

RETURN @ReturnCode

EXECUTE GetMembershipApplications 'On-hold'

delete from MembershipApplication
select * from MembershipApplication

create procedure RecordsMembershipApplication
(@FirstName varchar(15) = NULL, 
@LastName varchar(15) = NULL,
@Address varchar(20) = NULL,
@PostalCode varchar(6) = NULL,
@Phone varchar(10) = NULL,
@Email varchar(20) = NULL,
@DateOfBirth date = NULL,
@Occupation varchar(15) = NULL,
@CompanyName varchar(10) = NULL,
@CompanyAddress varchar(20) = NULL,
@CompanyPostalCode varchar(6) = NULL,
@CompanyPhone varchar(10) = NULL,
@ShareholderName varchar(30) = NULL, 
@Date date = NULL, 
@Status varchar(15) = NULL)
AS
	DECLARE @ReturnCode int
	SET @ReturnCode = 1

	
	IF @FirstName = null
	RAISERROR('Procedure: RecordsMembershipApplication- Add Parameter MemberFirstName',16,1)

	ELSE IF @LastName = null
	RAISERROR('Procedure: RecordsMembershipApplication- Add Parameter MemberLastName',16,1)

	ELSE IF @Status = null
	RAISERROR('Procedure: RecordsMembershipApplication- Add Parameter Status',16,1)

	ELSE 
	BEGIN
		INSERT INTO MembershipApplication
		(FirstName,LastName,Address, PostalCode, Phone, Email, DateOfBirth,Occupation,CompanyName,CompanyAddress,CompanyPostalCode,CompanyPhone,ShareholderName,Date,Status)
		VALUES
		(@FirstName,@LastName,@Address, @PostalCode, @Phone, @Email, @DateOfBirth,@Occupation,@CompanyName,@CompanyAddress,@CompanyPostalCode,@CompanyPhone,@ShareholderName,@Date,@Status)
		

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode




drop procedure UpdateMembershipApplication

create procedure UpdateMembershipApplication
(@MemberApplicationNumber int =null,
@FirstName varchar(15)=NULL,
@LastName varchar(15)=NULL,
@Address varchar(20)=NULL,
@PostalCode varchar(6)=NULL,
@Phone varchar(10)=NULL,
@Email varchar(20)=null,
@Status varchar(15) = NULL)
AS
	DECLARE @ReturnCode int
	SET @ReturnCode = 1


	BEGIN
		Update MembershipApplication
		set 
		FirstName=@FirstName,
		LastName=@LastName,
		Address=@Address,
		PostalCode=@PostalCode,
		Phone=@Phone,
		Email=@Email,		
		Status=@Status 
		where MemberApplicationNumber=@MemberApplicationNumber
		

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN Update',16,1)

	END

RETURN @ReturnCode
execute UpdateMembershipApplication 2,'Arsh','Dhillon','15125','T5Y0S2','7808025263','ARSHRAVIDHILLON','On-Hold'

select * from MembershipApplication
SELECT * FROM TeeTime


Create table Member(
MemberNumber int NOT NULL Primary Key,
FirstName varchar(15),
LastName varchar(15),
Address varchar(20),
PostalCode varchar(6),
Phone varchar(10),
Email varchar(20),
MemberType varchar(15) CHECK(MemberType='Shareholder' or MemberType='Non-Shareholder'))

drop procedure AddMember
Create procedure AddMember(
@MemberNumber int = NULL,
@FirstName varchar(15) = NULL,
@LastName varchar(15) =NULL,
@Address varchar(20) = NULL,
@PostalCode varchar(6) = NULL,
@Phone varchar(10) = NULL,
@Email varchar(20) = NULL,
@MemberType varchar(15) = NULL)
AS
	DECLARE @ReturnCode Int
	SET @ReturnCode=1
	
	IF @FirstName = null
	RAISERROR('Procedure: AddMember- Add Parameter FirstName',16,1)

	ELSE IF @LastName = null
	RAISERROR('Procedure: AddMember- Add Parameter LastName',16,1)

	ELSE IF @MemberType = null
	RAISERROR('Procedure: AddMember- Add Parameter MemberType',16,1)

	else

	Begin

	Insert into Member(MemberNumber,FirstName,LastName,Address,PostalCode,Phone,Email,MemberType)
	VALUES(@MemberNumber,@FirstName,@LastName,@Address,@PostalCode,@Phone,@Email,@MemberType)

	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END
	RETURN @ReturnCode

	drop table MemberAccount

create table MemberAccount(
MemberAccountNumber int NOT NULL Primary Key,
Balance money )

Create procedure AddMemberAccount(
@MemberAccountNumber int =NULL,
@Balance Money = NULL
)
AS
	DECLARE @ReturnCode Int
	SET @ReturnCode=1
	

	Begin

	Insert into MemberAccount(MemberAccountNumber,Balance)
	VALUES(@MemberAccountNumber,@Balance)
	

	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END
	RETURN @ReturnCode


	execute AddMemberAccount 3, '0','Deep','0','2020-02-21','2020-2-21','no'

Create procedure AddMemberAccountEntry(
@MemberAccountNumber int =NULL,
@Amount money = null,
@ActivityDate date=NULL,
@PostedDate date = NULL,
@Description varchar(20)
)
AS
	DECLARE @ReturnCode Int
	SET @ReturnCode=1
	

	Begin

	Insert into MemberAccountEntry(MemberAccountNumber ,Amount,ActivityDate,PostedDate,Description)
	Values(@MemberAccountNumber,@Amount,@ActivityDate,@PostedDate,@Description)
	
	

	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END
	RETURN @ReturnCode

	Execute AddMemberAccountEntry 16024,22,"2020-03-2","2020-03-05","Hello"

	select * from MemberAccountEntry

Create table MemberAccountEntry(
MemberAccountNumber int  NOT NULL,
Amount money,
ActivityDate datetime,
PostedDate datetime,
Description varchar(20))

Create table MemberAccountEntry1(
MemberAccountNumber int  NOT NULL,
Amount money,
ActivityDate datetime,
PostedDate datetime,
)

Create procedure AddMemberAccountEntry1(
@MemberAccountNumber int =NULL,
@Amount money = null,
@ActivityDate date=NULL,
@PostedDate date = NULL
)
AS
	DECLARE @ReturnCode Int
	SET @ReturnCode=1
	

	Begin

	Insert into MemberAccountEntry1(MemberAccountNumber ,Amount,ActivityDate,PostedDate)
	Values(@MemberAccountNumber,@Amount,@ActivityDate,@PostedDate)
	
	

	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END
	RETURN @ReturnCode
select * from MembershipApplication
select * from Member
select * from MemberAccount
select * from MemberAccountEntry


Create procedure GetMemberAccount(
@MemberAccountNumber int =NULL
)

AS
	DECLARE @ReturnCode Int
	SET @ReturnCode=1
	

	Begin

	Select Balance from MemberAccount where MemberAccountNumber=@MemberAccountNumber 
	
	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END
	RETURN @ReturnCode
	select * from MembershipApplication
	select * from MemberAccount
	execute GetMemberAccountEntry 16037
	select * from MemberAccountEntry

Create procedure GetMemberAccountEntry(
@MemberAccountNumber int =NULL
)

AS
	DECLARE @ReturnCode Int
	SET @ReturnCode=1
	

	Begin

	Select Amount,ActivityDate,PostedDate,Description from MemberAccountEntry where MemberAccountNumber=@MemberAccountNumber
	
	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END
	RETURN @ReturnCode
	
	Execute GetMemberAccountEntry 2

	
	create table PlayerScores(
	MemberNumber int,
	Course varchar(15) ,
	Rating decimal,
	Slope int,
	Date date,
	Score int, 
	Hole1 int,Hole2 int,Hole3 int,
	Hole4 int,Hole5 int,Hole6 int,
	Hole7 int,Hole8 int,Hole9 int,
	Hole10 int,Hole11 int,Hole12 int,
	Hole13 int,Hole14 int,Hole15 int,
	Hole16 int,Hole17 int,Hole18 int, 
	HandicapDifferential decimal)

insert into PlayerScores(Course, Rating, Slope, Date, Score, Hole1,Hole2,Hole3,Hole4,Hole5,Hole6,Hole7,Hole7,Hole9,Hole10,Hole11,Hole1,Hole13,Hole14,Hole15,Hole16,Hole17,Hole18)

create procedure AddPlayerScore(
@MemberNumber int=NULL,
@Course varchar(15) = NULL,
@Rating decimal =NULL,
@Slope int =NULL,
@Date date =NULL,
@Score int=NULL, 
@Hole1 int=NULL,@Hole2 int=NULL,@Hole3 int=NULL,
	@Hole4 int=NULL,@Hole5 int=NULL,@Hole6 int=NULL,
	@Hole7 int=NULL,@Hole8 int=NULL,@Hole9 int=NULL,
	@Hole10 int=NULL,@Hole11 int=NULL,@Hole12 int=NULL,
	@Hole13 int=NULL,@Hole14 int=NULL,@Hole15 int=NULL,
	@Hole16 int=NULL,@Hole17 int=NULL,@Hole18 int=NULL, 
	@HandicapDifferential decimal=NULL)

AS
	DECLARE @ReturnCode Int
	SET @ReturnCode=1
	

	Begin
		
	insert into PlayerScores(
	MemberNumber,
	Course, Rating, Slope, Date, 
	Score, Hole1,Hole2,Hole3,
	Hole4,Hole5,Hole6,
	Hole7,Hole8,Hole9,
	Hole10,Hole11,Hole12,
	Hole13,Hole14,Hole15,
	Hole16,Hole17,Hole18,HandicapDifferential) 
	values(@MemberNumber,@Course, @Rating, @Slope, @Date, @Score,
	@Hole1,@Hole2,@Hole3,
	@Hole4,@Hole5,@Hole6,
	@Hole7,@Hole8,@Hole9,
	@Hole10,@Hole11,@Hole12,
	@Hole13,@Hole14,@Hole15,
	@Hole16,@Hole17,@Hole18,@HandicapDifferential)

	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END
	RETURN @ReturnCode


	execute AddPlayerScore2 'ClubBaist',73,127,'2020-1-12',10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,80,123

	select * from PlayerScores
	
	drop procedure GetHandicapFactor

Create procedure GetHandicapFactor(@MemberNumber int= null)
AS
	DECLARE @ReturnCode Int
	SET @ReturnCode=1
	

	Begin

select round(128*(round(0.96*avg(HandicapDifferential),1))/113,1)from ( select TOP 10 PlayerScores.*
from (select TOP 20 PlayerScores.*,
             row_number() over (partition by MemberNumber order by date desc) as seqnum
      from PlayerScores
     ) PlayerScores
where MemberNumber = @MemberNumber ORDER BY HandicapDifferential desc) PlayerScores;

	IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END
	RETURN @ReturnCode

	execute GetHandicapFactor 16036

	select * from TeeTime

select * from PlayerScores

select 128*(round(0.96*avg(score),1))/113 from ( select TOP 10 PlayerScores.*
from (select TOP 20 PlayerScores.*,
             row_number() over (partition by MemberNumber order by date desc) as seqnum
      from PlayerScores
     ) PlayerScores
where MemberNumber = 1 ORDER BY Score desc) PlayerScores;



select 128*(round(0.96*avg(HandicapDifferential),1))/113 from ( select TOP 10 PlayerScores.*
from (select TOP 20 PlayerScores.*,
             row_number() over (partition by MemberNumber order by date desc) as seqnum
      from PlayerScores
     ) PlayerScores
where MemberNumber = 1 ORDER BY HandicapDifferential desc) PlayerScores;


SELECT TOP 2 
MAX(Score) OVER (PARTITION BY Date) 
FROM PlayerScores Where MemberNumber=1;





execute GetHandicapFactor
SELECT AVG(HandicapDifferential) from( select TOP 3 HandicapDifferential FROM(select PlayerScores.*
	from (select PlayerScores.*,
    row_number() over (partition by HandicapDifferential order by date desc) as seqnum
      from PlayerScores
     ) PlayerScores) PlayerScores order by HandicapDifferential desc ) AS Average

	
	
	SELECT top 2 score FROM PlayerScores ORDER BY Date DESC
	 delete from MemberAccountEntry

	 delete from MemberAccountEntry
	 select * from MemberAccountEntry
	 sp_help MemberAccountEntry
	 select * from Member
	 sp_help Member
	 select * from MembershipApplication
	 select * from MemberAccount
	 select * from StandingTeeTimeRequest
	 select * from TeeTime
	 SELECT * FROM Player
	 select * from PlayerScores

	 delete from PlayerScores

select 128*(round(0.96*avg(HandicapDifferential),1))/113 from ( select TOP 10 PlayerScores.*
from (select TOP 20 PlayerScores.*,
             row_number() over (partition by MemberNumber order by date desc) as seqnum
      from PlayerScores
     ) PlayerScores
where MemberNumber = 16036 ORDER BY HandicapDifferential desc) PlayerScores;

select TRUNCATE(10.900) FROM DUAL
SELECT ROUND(2.465,1);