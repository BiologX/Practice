-- PostgreSQL --

CREATE TABLE clients (
    id serial PRIMARY KEY,
    name varchar(100) NOT NULL,
    phone varchar(20) NOT NULL
);

CREATE TABLE devices (
    id serial PRIMARY KEY,
    model varchar(50) NOT NULL,
    serial_number varchar(50) NOT NULL
);

CREATE TABLE masters (
    id serial PRIMARY KEY,
    name varchar(50) NOT NULL,
    phone varchar(20) NOT NULL
);

CREATE TABLE malfunctions (
    id serial PRIMARY KEY,
    device_id int NOT NULL REFERENCES devices(id),
    title varchar(50) NOT NULL,
    description varchar(255)
);

CREATE TABLE requests (
    id serial PRIMARY KEY,
    device_id int NOT NULL REFERENCES devices(id),
    master_id int NOT NULL REFERENCES masters(id),
    client_id int NOT NULL REFERENCES clients(id),
    status varchar(20) NOT NULL
);