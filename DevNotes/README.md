# PostgreSQL table

```sql
-- Table: public."Person"

-- DROP TABLE public."Person";

CREATE TABLE public."Person"
(
  id integer NOT NULL,
  first_name character varying(50),
  last_name character varying(50),
  city character varying(50),
  CONSTRAINT pk_person PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public."Person"
  OWNER TO postgres;
GRANT ALL ON TABLE public."Person" TO postgres;
GRANT ALL ON TABLE public."Person" TO "dhsandbox-writer" WITH GRANT OPTION;
GRANT ALL ON TABLE public."Person" TO public;

```

# Output from /api/persons/
```javascript
[{
	"id": 1,
	"FirstName": "Darron",
	"LastName": "Haworth",
	"City": "Roseville"
}, {
	"id": 2,
	"FirstName": "Robin",
	"LastName": "Haworth",
	"City": "Roseville"
}, {
	"id": 3,
	"FirstName": "Kayla",
	"LastName": "Anderson",
	"City": "Roseville"
}, {
	"id": 4,
	"FirstName": "Jennifer",
	"LastName": "Johnson",
	"City": "Austin"
}, {
	"id": 5,
	"FirstName": "Brandon",
	"LastName": "Haworth",
	"City": "Ranch Cordova"
}]
```
# Outpub from /api/persons/4
```javascript
{
	"id": 4,
	"FirstName": "Jennifer",
	"LastName": "Johnson",
	"City": "Austin"
}
```