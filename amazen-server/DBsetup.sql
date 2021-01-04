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

CREATE TABLE vaults (
    id INT NOT NULL AUTO_INCREMENT,
    creatorId VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    isPrivate TINYINT NOT NULL,
)