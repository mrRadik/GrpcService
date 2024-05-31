create table if not exists public."File"
(
    "Name"         varchar,
    "Data"         bytea,
    "CreationTime" timestamp(0) with time zone default now(),
    "Extension"    varchar,
    "Id"           integer                     default nextval('file_id_seq'::regclass) not null
        constraint "File_pk"
            primary key,
    "Guid"         uuid
);

alter table public."File"
    owner to postgres;

grant delete, insert, select, update on public."File" to readwrite;