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


```sql
--Inserted the following to the “Persons” table:
INSERT INTO public."Person" (id, first_name, last_name, city) VALUES (1, 'Darron', 'Haworth', 'Roseville');
INSERT INTO public."Person" (id, first_name, last_name, city) VALUES (2, 'Robin', 'Haworth', 'Roseville');
INSERT INTO public."Person" (id, first_name, last_name, city) VALUES (3, 'Kayla', 'Anderson', 'Roseville');
INSERT INTO public."Person" (id, first_name, last_name, city) VALUES (4, 'Jennifer', 'Johnson', 'Austin');
INSERT INTO public."Person" (id, first_name, last_name, city) VALUES (5, 'Brandon', 'Haworth', 'Ranch Cordova');

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