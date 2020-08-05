CREATE DATABASE DB1

USE DB1
select * from student
CREATE TABLE Student(StudentId VARCHAR(10) NOT NULL PRIMARY KEY,
FirstName VARCHAR(10) NOT NULL, 
LastName VARCHAR(10)NOT NULL,
Email VARCHAR(15)NOT NULL,
ProgramCode VARCHAR(15))

drop table student

CREATE TABLE PROGRAM(ProgramCode VARCHAR(15) NOT NULL PRIMARY KEY,
Description VARCHAR(20) NOT NULL)
select * from program

ALTER TABLE Student ADD CONSTRAINT FK_PROGRAM FOREIGN KEY(ProgramCode) REFERENCES PROGRAM(ProgramCode)

SP_HELP STUDENT


INSERT INTO PROGRAM
(ProgramCode,Description)
VALUES
('CNT','ComputerNetworks')
INSERT INTO STUDENT
(StudentId,FirstName,LastName,Email,ProgramCode)
VALUES
(200465602,'Jass','brar','AB','CNT')

SELECT * FROM PROGRAM

create procedure AddProgram
(@ProgramCode varchar(10)=null,
@Description varchar(16)=null)
AS 
          DECLARE @RETURNCODE INT
		  SET @RETURNCODE=1

		  IF @ProgramCode IS NULL
		    RAISERROR('ADDPROGRAM-REQUIRED PARAMETER:@PROGRAMCODE',16,1)
		  ELSE
		     IF @DESCRIPTION IS NULL
			    RAISERROR('ADD DESCRIPTION-REQUIRED PARAMETER-@DESCRIPTION',16,1)
			ELSE

			  BEGIN
			     INSERT INTO PROGRAM(ProgramCode,Description)
				 VALUES
				 (@ProgramCode,@Description)

				 IF @@ERROR=0
				   SET @RETURNCODE=0
				ELSE
				   RAISERROR('ADDPROGRAM- INSERT ERROR: PROGRAM TABLE',16,1)

				END
RETURN @RETURNCODE


SP_HELP ADDPROGRAM

EXECUTE ADDPROGRAM 'test1','TEST DESCRIPTION1'

drop procedure DeleteProgram
Create Procedure UpdateProgram(@ProgramCode varchar(10) = null,
								@Description varchar(60) = null)

AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
If @ProgramCode is null
	RAISERROR('update program - required field:@programcode',16,1)

ELSE IF @Description is null
	RAISERROR('update program - required paeameter: @description',16,1)

Else


	UPDATE PROGRAM
	SET Description = @Description
	WHERE ProgramCode = @ProgramCode

IF @@ERROR = 0
	SET @ReturnCode = 0

ELSE
	RAISERROR('update program - update error: program table',16,1)

RETURN @ReturnCode


EXECUTE UpdateProgram 'test1','updated description1'

CREATE PROCEDURE DeleteProgram(@ProgramCode VARCHAR(10) = NULL)
AS
DECLARE @RETURNCODE INT
SET @RETURNCODE = 1

IF @ProgramCode IS NULL
	RAISERROR('DeleteProgram - require parameter: @ProgramCode',16,1)
ELSE
	BEGIN
		DELETE From Program
		where ProgramCode = @ProgramCode
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('DeleteProgram - Delete error: Program Table',16,1)
			END

			RETURN @ReturnCode

EXECUTE DeleteProgram 'Test'



CREATE PROCEDURE GetPrograms
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT ProgramCode,
	Description
	FROM PROGRAM
	IF @@ERROR  =0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GET PROGRAM - SLECT ERROR: PROGRAM CODE',16,1)

		RETURN @ReturnCode

		EXECUTE GetPrograms



CREATE PROCEDURE GetProgram(@ProgramCode VARCHAR(10) = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode= 1

	IF @ProgramCode IS NULL
		RAISERROR('GET PROGRAM: REQUIRE PARAMETE:@PROGRAMCODE',16,1)
	ELSE
		BEGIN
			SELECT Description
			FROM Program 
			WHERE ProgramCode = @ProgramCode

			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('GET PROGRAM- SELECT ERROR:PROGRAM TABLE',16,1)
			END

		RETURN @ReturnCode

		EXECUTE GetProgram "BAIST"

		drop procedure GetStudent

		select * from student
CREATE PROCEDURE GetStudent(@StudentId VARCHAR(10) = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @StudentId IS NULL
		RAISERROR('GETSTUDENT: REQUIRED PARAMETER',16,1)

	ELSE
		BEGIN
			SELECT StudentId,FirstName,LastName,Email
			FROM STUDENT WHERE StudentId = @StudentId


			IF @@ERROR  = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('GETSTUDENT-SELECT ERROR',16,1)
			END

		RETURN @ReturnCode

		EXECUTE GetStudent "200465601"

drop procedure AddStudent

CREATE PROCEDURE GetStudents(@ProgramCode VARCHAR(10) = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ProgramCode IS NULL
		RAISERROR('GETSTUDENT: REQUIRED PARAMETER',16,1)

	ELSE
		BEGIN
			SELECT StudentId,FirstName,LastName,Email
			FROM STUDENT WHERE ProgramCode = @ProgramCode

			IF @@ERROR  = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('GETSTUDENT-SELECT ERROR',16,1)
			END

		RETURN @ReturnCode

		EXECUTE GETSTUDENTS "BAIST"


CREATE PROCEDURE AddStudent
(@StudentId VARCHAR(10) = NULL,@FirstName VARCHAR(15) = NULL,@LastName VARCHAR(15) = NULL,@Email VARCHAR(20) = NULL,
@ProgramCode VARCHAR(15) = NULL)
AS 
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

IF @StudentId IS NULL
	RAISERROR('ADDSTUDENT-STUDENT_ID PARAMETER',16,1)

ELSE IF @FirstName IS NULL
	RAISERROR('ADDSTUDENT-FIRSTNAME',16,1)

ELSE IF @LastName IS NULL
	RAISERROR('ADDSTUDENT-LASTNAME',16,1)

ELSE IF @Email IS NULL
	RAISERROR('ADDSTUDENT-EMAIL',16,1)

ELSE IF @ProgramCode IS NULL
	RAISERROR('ADD STUDENT- PROGRAM',16,1)

ELSE
	BEGIN
		INSERT INTO STUDENT(StudentId,FirstName,LastName,Email,ProgramCode) VALUES(@StudentId,@FirstName,@LastName,@Email,@ProgramCode)

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

EXECUTE AddStudent "200465602","jone","dawn","@gmail","CNT"

EXECUTE AddProgram "CNT","NETWORK"

SELECT * FROM PROGRAM

CREATE PROCEDURE UpdateStudent(@StudentId VARCHAR(15) = NULL,@FirstName VARCHAR(15) = NULL,@LastName VARCHAR(15) = NULL,
@Email VARCHAR(15) = NULL,@ProgramCode VARCHAR(15) = NULL)
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

IF @StudentId IS NULL
	RAISERROR('UPDATE-STUDENTID',16,1)

ELSE
BEGIN
	UPDATE STUDENT
	SET FirstName = @FirstName,
	LastName = @LastName,
	 Email = @Email,
	 ProgramCode = @ProgramCode
	WHERE StudentId = @StudentId

IF @@ERROR = 0
	SET @ReturnCode = 0

ELSE
RAISERROR('UPDATE QUERY ERROR',16,1)

END

RETURN @ReturnCode

EXECUTE UpdateStudent "200465602","a1","l1","@a","CNT"

drop procedure DeleteStudent

CREATE PROCEDURE DeleteStudent(@StudentId VARCHAR(15) = NULL)
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

IF @StudentId IS NULL
	RAISERROR('DELETESTUDENT-STUDENT_ID',16,1)

ELSE
BEGIN

DELETE FROM STUDENT WHERE StudentId = @StudentId

IF
@@ERROR = 0
SET @ReturnCode = 0

ELSE
RAISERROR('DELETE QUERY',16,1)

END

RETURN @ReturnCode

EXECUTE DeleteStudent "2004601"

select * from student

CREATE PROCEDURE GetStudentss
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1


SELECT STUDENT_ID,FIRST_NAME,LAST_NAME,EMAIL,PROGRAM FROM STUDENT 

IF @@ERROR = 0
SET @ReturnCode = 0

else
RAISERROR('GETSTUDENTS : STUDENT: SELECT QUERY ',16,1)


RETURN @ReturnCode


EXECUTE GETSTUDENTSs 

drop procedure getstudentss
select * from Student
select * from PROGRAM