-- CREATE TABLE keeps (
--     id INT NOT NULL AUTO_INCREMENT,
--     creatorId VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(1000) NOT NULL,
--     img VARCHAR(255) NOT NULL,
--     views INT NOT NULL,
--     keeps INT NOT NULL,
--     shares INT NOT NULL,
--     PRIMARY KEY (id),
--     FOREIGN KEY (creatorId)
--         REFERENCES profiles(id)
--         ON DELETE CASCADE
-- )

-- CREATE TABLE vaults (
--     id INT NOT NULL AUTO_INCREMENT,
--     creatorId VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(1000) NOT NULL,
--     isPrivate TINYINT NOT NULL,
--     PRIMARY KEY (id),
--     FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE vaultKeeps (
--     id INT NOT NULL AUTO_INCREMENT,
--     vaultId INT NOT NULL,
--     keepId INT NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     FOREIGN KEY (vaultId)
--     REFERENCES vaults (id)
--     ON DELETE CASCADE,
--     FOREIGN KEY (keepId)
--     REFERENCES keeps (id)
--     ON DELETE CASCADE,
--     FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- )

-- DELETE FROM keeps WHERE creatorId='11559015-3313-4860-a032-831f6f22cd0c';

-- DELETE FROM vaults WHERE description='VAULT__DESCRIPTION';

-- DELETE FROM vaults WHERE name='MY__VAULT';

-- ALTER TABLE vaults
-- ADD img VARCHAR(255) NOT NULL

-- DELETE FROM vaults WHERE id='88';
-- DELETE FROM vaults WHERE id='89';

-- ALTER TABLE vaults
-- ADD img VARCHAR(255)


-- ALTER TABLE vaults
-- ADD img VARCHAR(255);

-- DELETE FROM keeps WHERE img='//placehold.it/200x200'

-- DELETE FROM vaults WHERE name='TEST_VAULT';
-- DELETE FROM vaults WHERE name='MY_VAULT';

-- DELETE FROM vaults WHERE creatorId='	d0b4d88a-d21e-457e-ada8-5efac23481c1';


-- DELETE * FROM vaults WHERE img=null;


DELETE FROM vaults WHERE creatorId='d0b4d88a-d21e-457e-ada8-5efac23481c1';


 