CREATE TABLE Income
(
  ID UUID NOT NULL,
  TRANSTIME TIMESTAMP NOT NULL,
  TRANSTYPE varchar(50) NOT NULL,
  AMOUNT INT NOT NULL,
  TRANSDETAILS VARCHAR(1000)
)