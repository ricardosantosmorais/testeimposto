IF OBJECT_ID('dbo.P_CFOP') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.P_CFOP
    IF OBJECT_ID('dbo.P_CFOP') IS NOT NULL
        PRINT '<<< FALHA APAGANDO A PROCEDURE dbo.P_CFOP >>>'
    ELSE
        PRINT '<<< PROCEDURE dbo.P_CFOP APAGADA >>>'
END
go
SET QUOTED_IDENTIFIER ON
GO
SET NOCOUNT ON 
GO 
CREATE PROCEDURE dbo.P_CFOP 
AS
BEGIN
	SELECT Cfop
	, SUM(BaseIcms) AS TotalBaseICMS
	, SUM(ValorIcms) AS TotalValorICMS
	, SUM(BaseIpi) AS TotalBaseIPI
	, SUM(ValorIpi) AS TotalValorIPI
	FROM NotaFiscalItem
	GROUP BY Cfop
END
GO
GRANT EXECUTE ON dbo.P_CFOP TO [public]
go
IF OBJECT_ID('dbo.P_NOTA_FISCAL') IS NOT NULL
    PRINT '<<< PROCEDURE dbo.P_CFOP CRIADA >>>'
ELSE
    PRINT '<<< FALHA NA CRIACAO DA PROCEDURE dbo.P_CFOP >>>'
go

