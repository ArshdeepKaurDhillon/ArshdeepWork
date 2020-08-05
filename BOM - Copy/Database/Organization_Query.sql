

/* Database */
create Database BOM
GO
Use BOM
GO

/* Tables and Insert Statements for Tables */

CREATE TABLE [Status]
(
	StatusID				INTEGER			IDENTITY(1,1)	PRIMARY KEY,
	Status					VARCHAR(30)		NULL
)
GO
INSERT INTO [Status] VALUES
('Active'),
('Inactive'),
('Ordered'),
('Shipped'),
('Cancelled'),
('Partially Shipped'),
('Available'),
('Discontinued'),
('In-Queue'),
('Enabled'),
('Disabled');
GO
CREATE TABLE [Address Type]
(
	AddressTypeID			INTEGER			IDENTITY(1,1)	PRIMARY KEY,
	AddressType				VARCHAR(10)		NULL
)
GO
INSERT INTO [Address Type] VALUES
('Permanent'),
('Business'),
('Education'),
('Billing'),
('Shipping');
GO
CREATE TABLE [Country Group]
(
	CountryCode				VARCHAR(5)		NULL,
	CountryName				VARCHAR(40)		NULL,
	CountryGroupID			INTEGER			NULL
)
GO
INSERT INTO [Country Group] VALUES
('CA', 'Canada', 1),
('US', 'United States', 1),
('AH', 'Afghanistan', 4),
('AF', 'Africa', 4),
('AX', 'Aland Islands', 4),
('AL', 'Albania', 2),
('AE', 'Algeria', 4),
('AS', 'American Samoa', 2),
('AN', 'Andorra', 4),
('AG', 'Angola', 4),
('AT', 'Argentina', 4),
('AM', 'Armenia', 3),
('AR', 'Aruba', 4),
('AU', 'Australia', 1),
('AA', 'Austria', 1),
('AZ', 'Azerbaijan', 2),
('BH', 'Bahamas, The', 1),
('BB', 'Bahrain', 1),
('BN', 'Bangladesh', 4),
('BA', 'Barbados', 1),
('BS', 'Belarus', 2),
('BE', 'Belgium', 1),
('BL', 'Belize', 2),
('BZ', 'Benin', 4),
('BD', 'Bermuda', 2),
('BU', 'Bhutan', 4),
('BV', 'Bolivia', 3),
('BO', 'Bosnia and Herzegovina', 2),
('BT', 'Botswana', 4),
('BR', 'Brazil', 4),
('BI', 'Brunei', 1),
('BG', 'Bulgaria', 2),
('BF', 'Burkina Faso', 4),
('BM', 'Burma', 4),
('BD', 'Burundi', 4),
('CD', 'Cambodia', 4),
('CM', 'Cameroon', 4),
('CV', 'Cape Verde', 3),
('KY', 'Cayman Islands', 4),
('CE', 'Ceylon', 4),
('CJ', 'Central African Republic', 4),
('CI', 'Chad', 4),
('CL', 'Chile', 4),
('CH', 'China', 1),
('CB', 'Colombia', 4),
('CM', 'Comoros', 4),
('CG', 'Congo, Rep.', 4),
('CR', 'Costa Rica', 4),
('CT', 'Cote Ivoire', 4),
('CO', 'Croatia', 1),
('CU', 'Cuba', 2),
('CY', 'Cyprus', 1),
('CK', 'Czech Republic', 1),
('DK', 'Denmark', 1),
('DO', 'Dominica', 4),
('DR', 'Dominican Public', 4),
('EQ', 'Ecuador', 4),
('EG', 'Egypt, Arab Rep.', 4),
('ES', 'El Salvador', 4),
('EL', 'Equatorial Guinea', 4),
('ER', 'Eritrea', 4),
('EO', 'Estonia', 1),
('ET', 'Ethiopia',4),
('FJ', 'Fuji', 3),
('FI', 'Finland', 1),
('FR', 'France', 1),
('GA', 'Gabon', 4),
('GI', 'Gambia, The', 4),
('GO', 'Georgia', 3),
('GE', 'Germany', 1),
('GH', 'Ghana', 4),
('GT', 'Gibraltar', 1),
('GB', 'Great Britain', 1),
('GR', 'Greece', 1),
('GL', 'Greenland', 1),
('GE', 'Grenada', 2),
('GM', 'Guatemala', 4),
('GU', 'Guam', 4),
('GG', 'Guinea', 4),
('GN', 'Guinea-Bissau', 4),
('GY', 'Guyana', 3),
('HA', 'Haiti', 4),
('HN', 'Honduras', 3),
('HO', 'Holland', 1),
('HK', 'Hong Kong', 1),
('HU', 'Hungary', 2),
('IC', 'Iceland', 1),
('II', 'India', 4),
('IO', 'Indonesia', 3),
('IR', 'Iran, Islamic Rep.', 2),
('IQ', 'Iraq', 2),
('IE', 'Ireland', 1),
('IS', 'Israel', 1),
('IT', 'Italy', 1),
('JA', 'Jamaica', 2),
('JP', 'Japan', 1),
('JO', 'Jordan', 2),
('KZ', 'Kazakhstan', 2),
('KE', 'Kenya', 4),
('KR', 'Khmer Republic', 4),
('KI', 'Kiribati', 4),
('KO', 'Korea, Rep.', 1),
('KS', 'Kosovo', 3),
('KU', 'Kuwait', 1),
('LA', 'Latvia', 1),
('LE', 'Lebanon', 2),
('LR', 'Liberia', 4),
('LB', 'Libya', 4),
('LI', 'Liechtenstein', 1),
('LT', 'Lithuania', 1),
('LU', 'Luxembourg', 1),
('MC', 'Macedonia', 2),
('MD', 'Madagascar', 4),
('ML', 'Malawi', 4),
('MG', 'Malagasy Rep.', 2),
('MY', 'Malaysia', 2),
('MI', 'Maldives', 4),
('MZ', 'Mali', 4),
('MT', 'Malta', 1),
('MH', 'Marshall Island', 4),
('MU', 'Mauritania', 3),
('MR', 'Mauritius', 4),
('MA', 'Mayotte', 2),
('MX', 'Mexico', 4),
('MF', 'Micronesia, Fed. Sts.', 3),
('MV', 'Moldova', 3),
('MC', 'Monaco', 1),
('MP', 'Mongolia', 4),
('MN', 'Montenegro', 2),
('MO', 'Morocco', 4),
('MX', 'Mozambique', 4),
('MY', 'Myanmar', 4),
('NM', 'Namibia', 4),
('NP', 'Nepal', 4),
('NL', 'Netherlands', 1),
('NG', 'New Guinea', 1),
('NZ', 'New Zealand', 1),
('NI', 'Nicaragua', 3),
('NE', 'Niger', 4),
('NR', 'Nigeria', 4),
('NF', 'Norfolk Island', 4),
('NO', 'Norway', 1),
('NA', 'North Africa', 1),
('NC', 'North Caledonia', 1),
('NK', 'North Korea', 1),
('OM', 'Oman', 1),
('PK', 'Pakistan', 4),
('PA', 'Palau', 3),
('PN', 'Panama', 2),
('PP', 'Papua New Guinea', 3),
('PG', 'Paraguay', 3),
('PU', 'Peru', 4),
('PH', 'Philippines', 3),
('PL', 'Poland', 2),
('PO', 'Portugal', 1),
('PR', 'Puerto Rico', 3),
('QA', 'Qatar', 1),
('RN', 'Romania', 2),
('RO', 'Rhodesia', 1),
('RM', 'Romania', 1),
('RU', 'Russia', 1),
('RW', 'Rwanda', 4),
('SM', 'San Marino', 1),
('SB', 'Saudi Arabia', 1),
('ST', 'Scotland', 1),
('SE', 'Senegal', 4),
('SC', 'Serbia', 2),
('SH', 'Seychelles', 2),
('SL', 'Sierra Leone', 4),
('SI', 'Singapore', 1),
('SD', 'Slovak Republic', 1),
('SG', 'Slovenia', 1),
('SM', 'Solomon Islands', 3),
('SO', 'Somalia', 4),
('SA', 'South Africa', 4),
('SX', 'South Korea', 4),
('SV', 'South Vietnam', 4),
('SN', 'Spain', 1),
('SR', 'Sri Lanka', 4),
('KN', 'St. Kitts and Nevis', 1),
('LC', 'St. Lucia', 2),
('VG', 'St. Vincent & Grenadines', 2),
('SU', 'Sudan', 4),
('SQ', 'Suriname', 2),
('SD', 'Swaziland', 4),
('SW', 'Sweden', 1),
('SZ', 'Switzerland', 1),
('SY', 'Syria', 3),
('TA', 'Taiwan', 2),
('TJ', 'Tajikistan', 4),
('TZ', 'Tanzania', 4),
('TH', 'Thailand', 2),
('TL', 'Timor-Leste', 3),
('TO', 'Togo', 4),
('TG', 'Tonga', 3),
('TR', 'Trinidad and Tobago', 1),
('TS', 'Tunisia', 4),
('TU', 'Turkey', 2),
('UG', 'Uganda', 4),
('UK', 'Ukraine', 3),
('UA', 'United Arab Emirates', 1),
('UM', 'United States Minor Outlying Islands', 4),
('UR', 'Uruguay', 4),
('UZ', 'Uzbekistan', 3),
('VC', 'Vatican City', 3),
('VA', 'Vanuatu', 3),
('VZ', 'Venezuela', 4),
('VE', 'Vietnam', 3),
('VI', 'Virgin Islands', 3),
('WA', 'Wales', 3),
('WB', 'West Bank and Gaza', 3),
('YE', 'Yemen, Rep.', 3),
('ZA', 'Zaire', 4),
('ZM', 'Zambia', 4),
('ZB', 'Zimbabwe', 4);
GO
CREATE TABLE [Region Group]
(
	RegionCode				VARCHAR(5)		NULL,
	RegionName				VARCHAR(40)		NULL,
	CountryCode				VARCHAR(5)		NULL
)
GO
INSERT INTO [Region Group] VALUES
--CANADA
('AB', 'Alberta', 'CA'),
('BC', 'British Columbia', 'CA'),
('MB', 'Manitoba', 'CA'),
('NB', 'New Brunswick', 'CA'),
('NL', 'Newfoundland and Labrador', 'CA'),
('NT', 'Northwest Territories', 'CA'),
('NS', 'Nova Scotia', 'CA'),
('NU', 'Nunavut', 'CA'),
('ON', 'Ontario', 'CA'),
('PE', 'Prince Edward Island', 'CA'),
('QC', 'Quebec', 'CA'),
('SK', 'Saskatchewan', 'CA'),
('YT', 'Yukon', 'CA'),
--USA
('AL', 'Alabama', 'US'),
('AK', 'Alaska', 'US'),
('AZ', 'Arizona', 'US'),
('AR', 'Arkansas', 'US'),
('CA', 'California', 'US'),
('CO', 'Colorado', 'US'),
('CT', 'Connecticut', 'US'),
('DE', 'Delaware', 'US'),
('FL', 'Florida', 'US'),
('GA', 'Georgia', 'US'),
('HI', 'Hawaii', 'US'),
('ID', 'Idaho', 'US'),
('IL', 'Illinois', 'US'),
('IN', 'Indiana', 'US'),
('IA', 'Iowa', 'US'),
('KS', 'Kansas', 'US'),
('KY', 'Kentucky', 'US'),
('LA', 'Louisiana', 'US'),
('ME', 'Maine', 'US'),
('MD', 'Maryland', 'US'),
('MA', 'Massachusetts', 'US'),
('MI', 'Michigan', 'US'),
('MN', 'Minnesota', 'US'),
('MS', 'Mississippi', 'US'),
('MO', 'Missouri', 'US'),
('MT', 'Montana', 'US'),
('NE', 'Nebraska', 'US'),
('NV', 'Nevada', 'US'),
('NH', 'New Hampshire', 'US'),
('NJ', 'New Jersey', 'US'),
('NM', 'New Mexico', 'US'),
('NY', 'New York', 'US'),
('NC', 'North Carolina', 'US'),
('ND', 'North Dakota', 'US'),
('OH', 'Ohio', 'US'),
('OK', 'Oklahoma', 'US'),
('OR', 'Oregon', 'US'),
('PA', 'Pennsylvania', 'US'),
('RI', 'Rhode Island', 'US'),
('SC', 'South Carolina', 'US'),
('SD', 'South Dakota', 'US'),
('TN', 'Tennessee', 'US'),
('TX', 'Texas', 'US'),
('UT', 'Utah', 'US'),
('VT', 'Vermont', 'US'),
('VA', 'Virginia', 'US'),
('WA', 'Washington', 'US'),
('WV', 'West Virginia', 'US'),
('WI', 'Wisconsin', 'US'),
('WY', 'Wyoming', 'US'),
('AA', 'American Armed Forces', 'US'),
('DC', 'District of Columbia', 'US'),
('GU', 'Guam', 'US'),
('PR', 'Puerto Rico', 'US'),
('VI', 'Virgin Islands', 'US');
GO
CREATE TABLE [Membership Roles]
(
	CustomerRoleID			INTEGER			IDENTITY(1,1)	PRIMARY KEY,
	CustomerRole			VARCHAR(30)		NULL
)
GO

CREATE TABLE [Customer Type]
(
	CustomerTypeID			INTEGER			IDENTITY(1,1)	PRIMARY KEY,
	CustomerType			VARCHAR(20)		NULL
)
GO
INSERT INTO [Customer Type] VALUES
('Person'),
('Organization Person'),
('Organization Country');
GO

CREATE TABLE [Organization Role]
(
	OrganizationRoleID		INTEGER			IDENTITY(1,1)	PRIMARY KEY,
	OrganizationRole		VARCHAR(70)		NULL
)
GO
INSERT INTO [Organization Role] VALUES
('Accounting'),
('Application Engineer'),
('Business Intelligence Analyst'),
('Data Warehouse Architect'),
('Director/Manager Operations, Planning, Administrative Services'),
('Director/Manager/Supervisor Data Processing'),
('EDP Auditing'),
('Education/Administration'),
('Education/Teacher'),
('Engineering'),
('Independent Consultant'),
('Manager/Supervisor of Programming'),
('Manufacturers Sales Representative'),
('Marketing'),
('Operations Research'),
('President/Owner/Partner/General Manager'),
('Programmer Analyst'),
('Programming (Business Applications)'),
('Programming (Scientific Applications)'),
('Programming (Software Systems)'),
('Research'),
('Staff Consultant'),
('Student'),
('Systems Analyst'),
('Systems Manager'),
('Treasurer/Controller/Financial Officer'),
('Vice President/Asst. VP'),
('Other');
GO
CREATE TABLE [Organization Type]
(
	OrganizationTypeID		INTEGER			IDENTITY(1,1)	PRIMARY KEY,
	OrganizationType		VARCHAR(30)		NULL
)
GO

INSERT INTO [Organization Type] VALUES
('Constituent'),
('Affiliate'),
('Corporate Sponsor'),
('Corporate Contractor'),
('Corporate Business Partner'),
('University/College'),
('Professional Assn'),
('Other')

GO
CREATE TABLE [Customer]
(
	CustomerID				INTEGER		IDENTITY(1,1)	PRIMARY KEY,
	CustomerTypeID			INTEGER		DEFAULT 1,	-- Individual
	CustomerName			VARCHAR(90)	NULL,
	CreateDate				DATETIME	DEFAULT GETDATE(),
	UpdateDate				DATETIME	NULL,
	StatusID				INTEGER		DEFAULT 1,	-- Active
	FOREIGN KEY (CustomerTypeID)		REFERENCES [Customer Type](CustomerTypeID),
	FOREIGN KEY (StatusID)				REFERENCES [Status](StatusID)
)
GO
CREATE TABLE [Customer Address]
(
	CustomerAddressID		INTEGER		IDENTITY(1,1)	PRIMARY KEY,
	CustomerID				INTEGER		NULL,
	OrgLocationID			INTEGER		NULL,
	AddressTypeID			INTEGER		NULL,
	Address					VARCHAR(50)	NULL,
	Address2				VARCHAR(50)	NULL,
	Country					VARCHAR(5)	NULL,
	Region					VARCHAR(5)	NULL,
	City					VARCHAR(40)	NULL,
	PostalCode				VARCHAR(10)	NULL,
	CompanyName				VARCHAR(50)	NULL,
	CompanyEmail			VARCHAR(70)	NULL,
	CompanyPhone			VARCHAR(30)	NULL,
	CreateDate				DATETIME	DEFAULT GETDATE(),
	UpdateDate				DATETIME	NULL,
	PreferredAddress		BIT			DEFAULT 0,
	FOREIGN KEY (CustomerID)			REFERENCES [Customer](CustomerID),
	FOREIGN KEY (AddressTypeID)			REFERENCES [Address Type](AddressTypeID),
)
GO
CREATE TABLE [Customer Role]
(
	CustomerID				INTEGER		NOT NULL,
	PersonRoleID			INTEGER		NOT NULL,
	PRIMARY KEY CLUSTERED (CustomerID, PersonRoleID),
	FOREIGN KEY (CustomerID)			REFERENCES [Customer](CustomerID),
	FOREIGN KEY (PersonRoleID)			REFERENCES [Membership Roles](CustomerRoleID)
)

GO

CREATE TABLE [Organization]
(
	OrganizationID			INTEGER		PRIMARY KEY,
	OrganizationTypeID		INTEGER		NULL,
	OtherOrgType   VARCHAR(50) NULL,
	OrganizationName		VARCHAR(50)	NULL,
	FOREIGN KEY (OrganizationID)		REFERENCES [Customer](CustomerID),
	FOREIGN KEY (OrganizationTypeID)	REFERENCES [Organization Type](OrganizationTypeID)
);
GO
CREATE TABLE [Organization Location]
(
	OrgLocationID			INTEGER		IDENTITY(1,1)	PRIMARY KEY,
	OrganizationID			INTEGER		NULL,
	OrgLocationName			VARCHAR(50)	NULL,
	OrgContactID			INTEGER		NULL,
	NumOfEmployees			INTEGER		DEFAULT 0,
	PreferredLocation		BIT			DEFAULT 0,
	FOREIGN KEY (OrganizationID)		REFERENCES [Customer](CustomerID)
);
GO
CREATE TABLE [Organization Contact]
(
	OrgContactID			INTEGER		IDENTITY(1,1)	PRIMARY KEY,
	OrganizationID			INTEGER		NULL,
	OrgLocationID			INTEGER		NULL,
	OrgCustomerID			INTEGER		NULL,
	OrgPersonRoleID			INTEGER		NULL,
	OtherOrgRole			VARCHAR(50)	NULL,
	PrimaryContact			VARCHAR(50) NULL,
	PhoneNumber				VARCHAR(30)	NULL,
	EmailAddress			VARCHAR(70)	NULL,
	FOREIGN KEY (OrganizationID)		REFERENCES [Organization](OrganizationID),
	FOREIGN KEY (OrgLocationID)			REFERENCES [Organization Location](OrgLocationID),
	FOREIGN KEY (OrgCustomerID)			REFERENCES [Customer](CustomerID),
	FOREIGN KEY (OrgPersonRoleID)		REFERENCES [Organization Role](OrganizationRoleID),
);
GO

CREATE TABLE [Organization Contact Role]
(
	OrgContactID			INTEGER		NOT NULL,
	OrganizationRoleID		INTEGER		NOT NULL,
	PRIMARY KEY CLUSTERED (OrgContactID, OrganizationRoleID),
	FOREIGN KEY (OrgContactID)			REFERENCES [Organization Contact](OrgContactID),
	FOREIGN KEY (OrganizationRoleID)	REFERENCES [Organization Role](OrganizationRoleID)
);
GO



/* Views For Organization */

CREATE VIEW [v_countries] AS 
SELECT CountryCode, CountryName FROM [Country Group]
GO

CREATE VIEW [v_organization_lookup_id] AS 
SELECT O.OrganizationName, O.OrganizationTypeID, O.OtherOrgType,C.StatusID, O.OrganizationID
FROM		[Organization] O	(NOLOCK)
LEFT JOIN	[Customer] C		(NOLOCK) ON C.CustomerID = O.OrganizationID
GO

/* Procedures For Organization */

CREATE PROCEDURE spCreateOrganization
@OrganizationName	VARCHAR(50) = NULL,
@OrganizationTypeID	INTEGER		= NULL,
@OtherOrgType VARCHAR(50) = NULL,
@CustomerID			INTEGER OUTPUT
AS
BEGIN
	INSERT INTO [Customer](CustomerTypeID, CustomerName)
	VALUES (3, @OrganizationName)
	SET @CustomerID = CONVERT(INT, SCOPE_IDENTITY())

	INSERT INTO [Organization](OrganizationID, OrganizationTypeID,OtherOrgType, OrganizationName)
	VALUES (@CustomerID, @OrganizationTypeID, @OtherOrgType, @OrganizationName)
	SELECT @CustomerID;
END

go

CREATE PROCEDURE spUpdateOrganization
@OrganizationID		INTEGER		= NULL,
@OrganizationName	VARCHAR(50) = NULL,
@OrganizationTypeID	INTEGER		= NULL,
@OtherOrgType VARCHAR(50) = NULL
AS
BEGIN
	UPDATE [Customer] SET UpdateDate = GETDATE()
	WHERE CustomerID = @OrganizationID

	UPDATE [Organization] SET OrganizationName = @OrganizationName, OrganizationTypeID = @OrganizationTypeID, OtherOrgType=@OtherOrgType
	WHERE OrganizationID = @OrganizationID
END
GO


CREATE PROCEDURE spAddOrganizationLocation
@CustomerID			INTEGER		= NULL,
@Address			VARCHAR(50)	= NULL,
@Country			VARCHAR(5)	= NULL,
@Region				VARCHAR(5)	= NULL,
@City				VARCHAR(40)	= NULL,
@PreferredLocation	BIT			= NULL,
@OrgLocationID		INTEGER OUTPUT
AS
BEGIN
	UPDATE [Customer] SET UpdateDate = GETDATE()
	WHERE CustomerID = @CustomerID

	INSERT INTO [Organization Location](OrganizationID, OrgLocationName, NumOfEmployees, PreferredLocation)
	VALUES (@CustomerID, (@Address + ' (' + @City + ', ' + @Region + ', ' + (SELECT CountryName FROM [Country Group] WHERE CountryCode = @Country) + ')'), NULL, @PreferredLocation)
	SET @OrgLocationID = CONVERT(INT, SCOPE_IDENTITY())

	INSERT INTO [Customer Address](CustomerID, OrgLocationID, AddressTypeID)
	VALUES (@CustomerID, @OrgLocationID, 4), (@CustomerID, @OrgLocationID, 5)
END
GO


CREATE PROCEDURE spUpdateOrganizationLocation
@CustomerID			INTEGER		= NULL,
@OrgLocationID		INTEGER		= NULL,
@AddressTypeID		INTEGER		= NULL,
@Address			VARCHAR(50)	= NULL,
@Address2			VARCHAR(50)	= NULL,
@City				VARCHAR(40)	= NULL,
@Region				VARCHAR(5)	= NULL,
@Country			VARCHAR(5)	= NULL,
@PostalCode			VARCHAR(10)	= NULL,
@PreferredLocation	BIT			= NULL
AS
BEGIN
	UPDATE [Customer] SET UpdateDate = GETDATE()
	WHERE CustomerID = @CustomerID

	UPDATE [Organization Location] SET OrgLocationName = (@Address + ' (' + @City + ', ' + @Region + ', ' + (SELECT CountryName FROM [Country Group] WHERE CountryCode = @Country) + ')'), PreferredLocation = @PreferredLocation
	WHERE OrganizationID = @CustomerID AND OrgLocationID = @OrgLocationID

	UPDATE [Customer Address] SET Address = @Address, Address2 = @Address2, City = @City, Region = @Region, Country = @Country, PostalCode = @PostalCode, UpdateDate = GETDATE()
	WHERE CustomerID = @CustomerID AND OrgLocationID = @OrgLocationID AND AddressTypeID = @AddressTypeID
END
GO

CREATE PROCEDURE spAddOrganizationContact
@CustomerID			INTEGER		= NULL,
@OrgLocationID		INTEGER		= NULL,
@OrgCustomerID		INTEGER		= NULL,
@OrgPersonRoleID	INTEGER		= NULL,
@OtherOrgRole		VARCHAR(50) = NULL,
@PrimaryContact		VARCHAR(50) = NULL,
@EmailAddress		VARCHAR(70)	= NULL,
@PhoneNumber		VARCHAR(30)	= NULL
AS
BEGIN
	UPDATE [Customer] SET UpdateDate = GETDATE()
	WHERE CustomerID = @CustomerID
	
	UPDATE [Organization Location] SET OrgContactID = @OrgCustomerID
	WHERE OrganizationID = @CustomerID AND OrgLocationID = @OrgLocationID

	INSERT INTO [Organization Contact](OrgLocationID, OrganizationID, OrgCustomerID, OrgPersonRoleID, OtherOrgRole,PrimaryContact,EmailAddress, PhoneNumber)
	VALUES (@OrgLocationID, @CustomerID, @OrgCustomerID, @OrgPersonRoleID,@OtherOrgRole, @PrimaryContact,@EmailAddress, @PhoneNumber)

	DECLARE @OrgContactID INTEGER = NULL
	SET @OrgContactID = CONVERT(INT, SCOPE_IDENTITY())

	INSERT INTO [Organization Contact Role](OrgContactID, OrganizationRoleID)
	VALUES (@OrgContactID, @OrgPersonRoleID)
END
GO

CREATE PROCEDURE spRemoveOrganizationContact
@CustomerID			INTEGER		= NULL,
@OrgLocationID		INTEGER		= NULL
AS
BEGIN
	UPDATE [Customer] SET UpdateDate = GETDATE()
	WHERE CustomerID = @CustomerID

	UPDATE [Organization Location] SET OrgContactID = NULL
	WHERE OrganizationID = @CustomerID AND OrgLocationID = @OrgLocationID
	
	DELETE FROM [Organization Contact Role] WHERE OrgContactID = (SELECT OrgContactID FROM [Organization Contact] WHERE OrganizationID = @CustomerID AND OrgLocationID = @OrgLocationID)
	DELETE FROM [Organization Contact] WHERE OrganizationID = @CustomerID AND OrgLocationID = @OrgLocationID
END
GO

CREATE PROCEDURE spUpdateOrganizationContact
@CustomerID			INTEGER		= NULL,
@OrgLocationID		INTEGER		= NULL,
@OrgCustomerID		INTEGER		= NULL,
@OrgPersonRoleID	INTEGER		= NULL,
@OtherOrgRole		VARCHAR(50)	= NULL,
@PrimaryContact		VARCHAR(50) = NULL,
@PhoneNumber		VARCHAR(30)	= NULL,
@EmailAddress		VARCHAR(70)	= NULL
AS
BEGIN
	UPDATE [Customer] SET UpdateDate = GETDATE()
	WHERE CustomerID = @CustomerID

	UPDATE [Organization Location] SET OrgContactID = @OrgCustomerID WHERE OrganizationID = @CustomerID AND OrgLocationID = @OrgLocationID

	UPDATE [Organization Contact] SET OrgPersonRoleID = @OrgPersonRoleID, OtherOrgRole=@OtherOrgRole, PrimaryContact=@PrimaryContact, PhoneNumber = @PhoneNumber, EmailAddress = @EmailAddress
	WHERE OrganizationID = @CustomerID AND OrgLocationID = @OrgLocationID
	
	UPDATE [Organization Contact Role] SET OrganizationRoleID = @OrgPersonRoleID
	WHERE OrgContactID = (SELECT OrgContactID FROM [Organization Contact] WHERE OrgLocationID = @OrgLocationID)
END
GO

CREATE PROCEDURE spLookupOrganizationByValue
@Country			VARCHAR(10)	= NULL,
@Region				VARCHAR(10)	= NULL,
@PostalCode			VARCHAR(10) = NULL
AS
BEGIN
	SELECT DISTINCT C.CustomerID, (SELECT '(ORG) ' + O.OrganizationName) AS 'CustomerName', O.OrganizationName, OC.EmailAddress, OC.PhoneNumber, CA.Address, CA.City, CA.Region, CA.Country, CA.PostalCode
	FROM		[Customer] C				(NOLOCK)
	INNER JOIN	[Organization] O			(NOLOCK) ON O.OrganizationID = C.CustomerID
	INNER JOIN	[Organization Location] OL	(NOLOCK) ON OL.OrganizationID = O.OrganizationID
	LEFT JOIN	[Customer Address] CA		(NOLOCK) ON CA.CustomerID = O.OrganizationID
	LEFT JOIN	[Organization Contact] OC	(NOLOCK) ON OC.OrganizationID = O.OrganizationID AND OC.OrgLocationID = OL.OrganizationID
	WHERE CA.AddressTypeID = 4 AND C.CustomerTypeID = 3 AND C.StatusID = 1 AND (CA.Country = @Country OR CA.Region = @Region OR CA.PostalCode = @PostalCode)
	ORDER BY C.CustomerID DESC
END
go

CREATE PROCEDURE spLookupOrganizationLocation
@CustomerID			INTEGER		= NULL,
@OrgLocationID		INTEGER		= NULL
AS
BEGIN
	SELECT OL.OrgLocationID, OC.OrgCustomerID, AT.AddressTypeID, CA.Address, CA.Address2, CA.Country, CA.Region, CA.City, CA.PostalCode, OL.PreferredLocation
	FROM		[Organization Location] OL	(NOLOCK)
	LEFT JOIN	[Customer Address] CA		(NOLOCK) ON CA.OrgLocationID = OL.OrgLocationID
	LEFT JOIN	[Address Type] AT			(NOLOCK) ON AT.AddressTypeID = CA.AddressTypeID
	LEFT JOIN	[Organization Contact] OC	(NOLOCK) ON OC.OrgCustomerID = OL.OrganizationID
	WHERE CA.CustomerID = @CustomerID AND OL.OrgLocationID = @OrgLocationID
END
GO

CREATE PROCEDURE spLookupOrganizationContact
@OrganizationID		INTEGER		= NULL,
@OrgContactID		INTEGER		= NULL
AS
BEGIN
	SELECT	OCRN.OrganizationRoleID, OCN.EmailAddress,OCN.OtherOrgRole,OCN.PhoneNumber,OCN.PrimaryContact
	FROM 		[Organization Contact] OCN		(NOLOCK)
	LEFT JOIN	[Organization Contact Role] OCRN	(NOLOCK) ON OCRN.OrgContactID = OCN.OrgContactID
	WHERE OCN.OrgCustomerID = @OrganizationID AND OCN.OrganizationID = @OrganizationID
END
GO

CREATE PROCEDURE spLookupOrgContact
@OrganizationID		INTEGER		= NULL
AS
BEGIN
	select * from [Organization Contact] where OrganizationID=@OrganizationID
END
GO

GO

create procedure GetCountries

AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	BEGIN
	SELECT * FROM v_countries 
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN select',16,1)

	END

RETURN @ReturnCode

GO

GO
create procedure GetOrganizations

AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	BEGIN
	SELECT * FROM [Organization]
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN select',16,1)

	END

RETURN @ReturnCode

GO

create procedure GetOrganizationID(@OrganizationName varchar(50)=NULL)

AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	BEGIN
	SELECT OrganizationID FROM [Organization] where OrganizationName=@OrganizationName
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN select',16,1)

	END

RETURN @ReturnCode

GO

create procedure GetOrganizationLocationID(@OrganizationID INT=NULL)
AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	BEGIN
	SELECT OrgLocationID FROM [Organization Location] where OrganizationID=@OrganizationID
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN select',16,1)

	END
RETURN @ReturnCode

GO
create procedure GetOrganizationType

AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	BEGIN
	SELECT * FROM [Organization Type]
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN select',16,1)

	END

RETURN @ReturnCode
GO

create procedure GetOrganizationRole

AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	BEGIN
	SELECT * FROM [Organization Role]
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN select',16,1)

	END

RETURN @ReturnCode
GO
create procedure GetRegions

AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	BEGIN
	SELECT RegionCode,RegionName FROM [Region Group] where CountryCode='CA'
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN select',16,1)

	END

RETURN @ReturnCode

GO

create procedure GetOrganizationContactID(@OrganizationID INT=NULL)
AS
	DECLARE @ReturnCode Int
	set @ReturnCode = 1

	BEGIN
	SELECT OrgContactID FROM [Organization Contact] where OrganizationID=@OrganizationID
			IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN select',16,1)

	END
RETURN @ReturnCode

go
/*
select * from Organization
SELECT * FROM [Organization Contact Role]
select * from [Organization Contact]
SELECT * FROM [Organization Location]
select * from [Customer Address]

execute GetOrganizationLocationID 2 */