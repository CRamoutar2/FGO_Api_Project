CREATE DATABASE FGO;
USE FGO;

SET SQL_SAFE_UPDATES = 0;
CREATE TABLE Servants(
	ServantNumber INT NOT NULL AUTO_INCREMENT,
	ServantName VARCHAR(500) NOT NULL,
    StarRarity INT NOT NULL,
    isOwned BOOLEAN NOT NULL,
    PRIMARY KEY (ServantNumber)
);

 CREATE TABLE NoblePhantasms(
	NpID INT NOT NULL AUTO_INCREMENT,
	NpName VARCHAR (500) NOT NULL,
    NpLevel INT NOT NULL,
    CorrespondingServantNumber INT NOT NULL,
    PRIMARY KEY (NpID)
);

update noblephantasms
set CorrespondingServantNumber = NpID
where CorrespondingServantNumber = 0;

ALTER TABLE servants ADD UNIQUE(ServantName);
ALTER TABLE noblephantasms ADD FOREIGN KEY (CorrespondingServantNumber) REFERENCES servants(servantnumber);
SET SQL_SAFE_UPDATES = 1;

#select servants.starrarity, servants.Servantname, noblephantasms.Npname, noblephantasms.nplevel, servants.isowned
#	FROM servants
#	 JOIN Noblephantasms ON servants.servantnumber=noblephantasms.npid
#		order by servants.servantnumber;