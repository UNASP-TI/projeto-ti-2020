
CREATE TABLE produto_has_fornecedor(
	IdFornecedor INT NOT NULL,
	IdProduto INT NOT NULL,
	PRIMARY KEY (IdFornecedor, IdProduto),
	FOREIGN KEY(IdFornecedor) REFERENCES fornecedor(IdFornecedor),
	FOREIGN KEY(IdProduto) REFERENCES produto(id)
);