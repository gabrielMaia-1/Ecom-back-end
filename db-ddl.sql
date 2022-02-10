CREATE SCHEMA IF NOT EXISTS cad;

CREATE SCHEMA IF NOT EXISTS staff;

CREATE SCHEMA IF NOT EXISTS ped;

CREATE SEQUENCE cad.sq_cidade;

CREATE SEQUENCE cad.sq_endereco;

CREATE SEQUENCE staff.sq_equipe;

CREATE SEQUENCE cad.sq_estado;

CREATE SEQUENCE ped.sq_pedido;

CREATE SEQUENCE cad.sq_produto;

CREATE SEQUENCE cad.sq_veiculo;

CREATE TABLE cad.estado (
    id integer NOT NULL DEFAULT (nextval('cad.sq_estado'::regclass)),
    nome character varying NOT NULL,
    uf character varying(2) NOT NULL,
    CONSTRAINT "PK_estado" PRIMARY KEY (id)
);

CREATE TABLE cad.produto (
    id integer NOT NULL DEFAULT (nextval('cad.sq_produto'::regclass)),
    nome character varying NOT NULL,
    descricao character varying NOT NULL,
    valor numeric NOT NULL,
    CONSTRAINT "PK_produto" PRIMARY KEY (id)
);

CREATE TABLE cad.usuario (
    id integer NOT NULL DEFAULT (nextval('cad.usuario'::regclass)),
    username character varying NOT NULL,
    password character varying NOT NULL,
    role character varying NOT NULL,
    CONSTRAINT "PK_usuario" PRIMARY KEY (id)
);

CREATE TABLE cad.veiculo (
    id integer NOT NULL DEFAULT (nextval('cad.sq_veiculo'::regclass)),
    placa character varying NOT NULL,
    CONSTRAINT "PK_veiculo" PRIMARY KEY (id)
);

CREATE TABLE cad.cidade (
    id integer NOT NULL DEFAULT (nextval('cad.sq_cidade'::regclass)),
    estado_id integer NOT NULL,
    nome character varying NOT NULL,
    CONSTRAINT "PK_cidade" PRIMARY KEY (id),
    CONSTRAINT fk_estado FOREIGN KEY (estado_id) REFERENCES cad.estado (id) ON DELETE RESTRICT
);

CREATE TABLE staff.equipe (
    id integer NOT NULL DEFAULT (nextval('staff.sq_equipe'::regclass)),
    nome character varying NOT NULL,
    descricao character varying NOT NULL,
    veiculo_id integer NOT NULL,
    CONSTRAINT "PK_equipe" PRIMARY KEY (id),
    CONSTRAINT fk_veiculo FOREIGN KEY (veiculo_id) REFERENCES cad.veiculo (id) ON DELETE RESTRICT
);

CREATE TABLE cad.endereco (
    id integer NOT NULL DEFAULT (nextval('cad.sq_endereco'::regclass)),
    nome character varying NOT NULL,
    cidade_id integer NOT NULL,
    cep character varying(8) NOT NULL,
    CONSTRAINT "PK_endereco" PRIMARY KEY (id),
    CONSTRAINT fk_cidade FOREIGN KEY (cidade_id) REFERENCES cad.cidade (id) ON DELETE RESTRICT
);

CREATE TABLE ped.pedido (
    id integer NOT NULL DEFAULT (nextval('ped.sq_pedido'::regclass)),
    data_inclusao timestamp without time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    data_entrega timestamp without time zone NOT NULL,
    endereco_id integer NOT NULL,
    CONSTRAINT "PK_pedido" PRIMARY KEY (id),
    CONSTRAINT fk_endereco FOREIGN KEY (endereco_id) REFERENCES cad.endereco (id) ON DELETE RESTRICT
);

CREATE TABLE ped.pedido_produto (
    id_pedido integer NOT NULL,
    id_produto integer NOT NULL,
    CONSTRAINT pedido_produto_pkey PRIMARY KEY (id_pedido, id_produto),
    CONSTRAINT fk_pedido FOREIGN KEY (id_pedido) REFERENCES ped.pedido (id) ON DELETE RESTRICT,
    CONSTRAINT fk_produto FOREIGN KEY (id_produto) REFERENCES cad.produto (id) ON DELETE RESTRICT
);

-- Outros

CREATE OR REPLACE VIEW ped.v_fato_pedidos
AS SELECT p.id AS pedido_id,
    p.data_inclusao,
    p.data_entrega,
    p.endereco_id,
    e.nome AS endereco,
    e.cidade_id,
    c.nome AS cidade,
    c.estado_id,
    e2.nome AS estado,
    e2.uf,
    e.cep,
    p2.id AS produto_id,
    p2.nome AS produto,
    p2.descricao AS descricao_produto,
    p2.valor AS valor_produto
   FROM ped.pedido p
     JOIN cad.endereco e ON p.endereco_id = e.id
     JOIN cad.cidade c ON e.cidade_id = c.id
     JOIN cad.estado e2 ON c.estado_id = e2.id
     JOIN ped.pedido_produto pp ON pp.id_pedido = p.id
     JOIN cad.produto p2 ON pp.id_produto = p2.id
  ORDER BY p.data_inclusao;