-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 13-Mar-2020 às 14:33
-- Versão do servidor: 10.1.13-MariaDB
-- PHP Version: 7.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projeto_3ti`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `fornecedor`
--

CREATE TABLE `fornecedor` (
  `IdFornecedor` int(11) NOT NULL,
  `NomeFornecedor` varchar(50) NOT NULL,
  `ContatoFornecedor` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `fornecedor`
--

INSERT INTO `fornecedor` (`IdFornecedor`, `NomeFornecedor`, `ContatoFornecedor`) VALUES
(1, 'Alciomar', '21188020');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `id` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `preco_custo` decimal(10,2) DEFAULT NULL,
  `preco_venda` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`id`, `nome`, `preco_custo`, `preco_venda`) VALUES
(1, 'Windows', NULL, NULL),
(2, 'Windows', NULL, NULL),
(3, 'Windows', NULL, NULL),
(4, 'Livro', NULL, NULL),
(5, 'Caderno', NULL, NULL),
(6, 'klkl', NULL, NULL),
(7, 'Ricardo', NULL, NULL),
(8, 'Tcc', '10.00', NULL),
(9, 'Celular', '20.00', '1500.00'),
(10, 'Monitor 50', '50.00', '1000.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto_has_fornecedor`
--

CREATE TABLE `produto_has_fornecedor` (
  `IdFornecedor` int(11) NOT NULL,
  `IdProduto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `produto_has_fornecedor`
--

INSERT INTO `produto_has_fornecedor` (`IdFornecedor`, `IdProduto`) VALUES
(1, 10);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `fornecedor`
--
ALTER TABLE `fornecedor`
  ADD PRIMARY KEY (`IdFornecedor`);

--
-- Indexes for table `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `produto_has_fornecedor`
--
ALTER TABLE `produto_has_fornecedor`
  ADD PRIMARY KEY (`IdFornecedor`,`IdProduto`),
  ADD KEY `IdProduto` (`IdProduto`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `fornecedor`
--
ALTER TABLE `fornecedor`
  MODIFY `IdFornecedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `produto`
--
ALTER TABLE `produto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `produto_has_fornecedor`
--
ALTER TABLE `produto_has_fornecedor`
  ADD CONSTRAINT `produto_has_fornecedor_ibfk_1` FOREIGN KEY (`IdFornecedor`) REFERENCES `fornecedor` (`IdFornecedor`),
  ADD CONSTRAINT `produto_has_fornecedor_ibfk_2` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
