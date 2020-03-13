select * from produto_has_fornecedor as pf
inner join produto as p on p.id =  pf.IdProduto
inner join fornecedor as f on f.IdFornecedor =  pf.IdFornecedor