DELETE  FROM dbo.tblNavigation
WHERE   ID = '9B08ED27-4B5D-4681-9ADB-79427699121A'

UPDATE  dbo.tblNavigation
SET     WindowString = 'ComenziListe.ListaComenziFiltru, ComenziListe'
WHERE   ID = '0F3761AD-01C6-4293-8641-D9DEBB89B3B9'

UPDATE  dbo.tblListeBase
SET     ExportEnabled = 0 ,
        ExportFileName = 'Lista comenzi'
WHERE   ID = '69298897-4A4E-4175-B335-A257108B51E5'

IF EXISTS ( SELECT TOP 1 1 FROM dbo.tblNavigation WHERE ID = '74d94323-f5b1-44f0-a731-ce073158099e') 
	UPDATE dbo.tblNavigation SET Node = 2, NAME = 'Disponibil Centru', Description = 'Disponibil Centru', NavigateUrl = NULL, Permission = '0', ParentGroupID = 'e9064055-3d3d-420f-aab2-300cdfcb7da0', PreCondition = NULL, QueryString = NULL, Title = 'Disponibil Centre', WindowString = 'ComenziListe.DisponibilCentreFiltre, ComenziListe', IsDialogWindow = -1, IsWeb = 0, IsWindow = 0, ModulID = 'a25a1d73-1c06-4074-aadf-1caa51705822', AplicatiiID = '16eeff75-d7b1-4af5-8b01-e2b8d786f765', ShortcutValue = NULL WHERE ID = '74d94323-f5b1-44f0-a731-ce073158099e' 
ELSE
	INSERT dbo.tblNavigation (ID, Node, NAME, Description, NavigateUrl, Permission, ParentGroupID, PreCondition, QueryString, Title, WindowString, IsDialogWindow, IsWeb, IsWindow, ModulID, AplicatiiID, ShortcutValue) VALUES ('74d94323-f5b1-44f0-a731-ce073158099e', 2, 'Disponibil Centru', 'Disponibil Centru', NULL, '0', 'e9064055-3d3d-420f-aab2-300cdfcb7da0', NULL, NULL, 'Disponibil Centre', 'ComenziListe.DisponibilCentreFiltre, ComenziListe', -1, 0, 0, 'a25a1d73-1c06-4074-aadf-1caa51705822', '16eeff75-d7b1-4af5-8b01-e2b8d786f765', NULL)
GO
IF EXISTS ( SELECT TOP 1 1 FROM dbo.tblListeBase WHERE ID = 'c57c3311-cfe4-49e8-9fcc-fe3434554aa6') 
	UPDATE dbo.tblListeBase SET AssemblyName = 'ComenziListe.ListaDisponibil, ComenziListe', Denumire = 'Lista Disponibil', IsUserSpecific = 0, ExportFileName = 'Lista Disponibil', ExportEnabled = 0 WHERE ID = 'c57c3311-cfe4-49e8-9fcc-fe3434554aa6' 
ELSE
	INSERT dbo.tblListeBase VALUES ('c57c3311-cfe4-49e8-9fcc-fe3434554aa6', 'ComenziListe.ListaDisponibil, ComenziListe', 'Lista Disponibil', 0, 'Lista Disponibil', 0)
GO
IF EXISTS ( SELECT TOP 1 1 FROM dbo.tblNavigation WHERE ID = 'E0A7F47A-A5E3-48EA-8FB4-A26ABF6BDEAD') 
	UPDATE dbo.tblNavigation SET Node = 2, NAME = 'Executie Contracte', Description = 'Executie Contracte', NavigateUrl = NULL, Permission = '0', ParentGroupID = 'e9064055-3d3d-420f-aab2-300cdfcb7da0', PreCondition = NULL, QueryString = NULL, Title = 'Executie Contracte', WindowString = 'ComenziListe.ExecutieContracteFiltre, ComenziListe', IsDialogWindow = -1, IsWeb = 0, IsWindow = 0, ModulID = 'a25a1d73-1c06-4074-aadf-1caa51705822', AplicatiiID = '16eeff75-d7b1-4af5-8b01-e2b8d786f765', ShortcutValue = NULL WHERE ID = 'E0A7F47A-A5E3-48EA-8FB4-A26ABF6BDEAD' 
ELSE
	INSERT dbo.tblNavigation (ID, Node, NAME, Description, NavigateUrl, Permission, ParentGroupID, PreCondition, QueryString, Title, WindowString, IsDialogWindow, IsWeb, IsWindow, ModulID, AplicatiiID, ShortcutValue) VALUES ('E0A7F47A-A5E3-48EA-8FB4-A26ABF6BDEAD', 2, 'Executie Contracte', 'Executie Contracte', NULL, '0', 'e9064055-3d3d-420f-aab2-300cdfcb7da0', NULL, NULL, 'Executie Contracte', 'ComenziListe.ExecutieContracteFiltre, ComenziListe', -1, 0, 0, 'a25a1d73-1c06-4074-aadf-1caa51705822', '16eeff75-d7b1-4af5-8b01-e2b8d786f765', NULL)
GO
IF EXISTS ( SELECT TOP 1 1 FROM dbo.tblListeBase WHERE ID = 'F054CFBF-6073-4E63-ABCD-7246A35A2D05') 
	UPDATE dbo.tblListeBase SET AssemblyName = 'ComenziListe.ExecutieContracte, ComenziListe', Denumire = 'Executie Contracte', IsUserSpecific = 0, ExportFileName = 'Executie Contracte', ExportEnabled = 0 WHERE ID = 'F054CFBF-6073-4E63-ABCD-7246A35A2D05' 
ELSE
	INSERT dbo.tblListeBase VALUES ('F054CFBF-6073-4E63-ABCD-7246A35A2D05', 'ComenziListe.ExecutieContracte, ComenziListe', 'Executie Contracte', 0, 'Executie Contracte', 0)
GO

IF NOT EXISTS ( SELECT  sc.name
            FROM    sysobjects so
                    INNER JOIN syscolumns sc ON so.id = sc.id
            WHERE   ( so.name = 'tblPersoane' )
                    AND ( sc.name = 'CentruID' ) )
    BEGIN
        ALTER TABLE dbo.tblPersoane ADD  CentruID UNIQUEIDENTIFIER NULL 
    END 
GO

IF NOT EXISTS ( SELECT  *
                FROM    sys.foreign_keys
                WHERE   object_id = OBJECT_ID(N'[dbo].[FK_tblPersoane_tblCentru]')
                        AND parent_object_id = OBJECT_ID(N'[dbo].[tblPersoane]') ) 
    ALTER TABLE [dbo].[tblPersoane]  WITH CHECK ADD  CONSTRAINT [FK_tblPersoane_tblCentru] FOREIGN KEY(CentruID) REFERENCES [dbo].[tblCentru] ([ID])
GO
UPDATE  dbo.tblPersoane
SET     CentruID = ( SELECT TOP 1
                            A.CentruID
                     FROM   dbo.lnkPersoanaTipPersoana A
                     WHERE  a.PersoanaID = dbo.tblPersoane.ID
                   )
WHERE   dbo.tblPersoane.CentruID IS NULL

/*************************************************************************************************************
 SCRIPT NAME		: Scrit_CreareFunctieGetNumarFromString
 DESCRIPTION		: Scriptul creaza functia ce returneaza un numar dintr-un string
					
 VERSION		: v1
 DATE			: 20.10.2015
 ORIGINAL AUTHORS	: MaganMihai
 REVISION AUTHORS	:
 INPUT			: un sir de caractere 
 OUTPUT			: un sir de caractere ce reprezinta numarul extras din input
 DEPENDENCIES	:
 REMARKS		:
 WARNINGS		: 
*************************************************************************************************************/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects
   WHERE id = object_id(N'udf_GetNumarFromString') AND OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
   DROP FUNCTION udf_GetNumarFromString
GO

CREATE FUNCTION [dbo].[udf_GetNumarFromString]
						(@input VARCHAR(256))
				RETURNS VARCHAR(256)
AS
BEGIN
	DECLARE @InitialNumber INT
		SET @InitialNumber = PATINDEX('%[^0-9]%', @input)
		BEGIN
			WHILE @InitialNumber > 0 
								BEGIN
									SET @input = STUFF(@input, @InitialNumber, 1, NULL )
									SET @InitialNumber = PATINDEX('%[^0-9]%', @input )
								END
		END
IF ISNULL(@input,'-1')!='-1' AND LEN(@input)>10
 SET @input='0'

RETURN ISNULL(@input,0)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS(SELECT * FROM sysobjects
				WHERE id=OBJECT_ID(N'[dbo].[usp_GetMaxSimbolFromTable]') AND 
				      OBJECTPROPERTY(id,N'IsProcedure')=1)
		 DROP PROCEDURE [dbo].[usp_GetMaxSimbolFromTable]
GO

CREATE PROCEDURE usp_GetMaxSimbolFromTable(
 @tableName NVARCHAR(250)='',
 @tableColumn NVARCHAR(250)='',
 @Filtru      NVARCHAR(250)='' 
 ) AS
 BEGIN
 DECLARE @StrString NVARCHAR(1500);
 
 IF ISNULL(@tableName,'')!='' AND  EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
              WHERE TABLE_NAME=@tableName)
 BEGIN
	IF ISNULL(@tableColumn,'')!='' AND EXISTS (SELECT * FROM  sys.columns 
							WHERE Name = @tableColumn AND Object_ID = Object_ID(@tableName))
	BEGIN     
	
	SET @StrString='SELECT MAX(CAST(dbo.udf_GetNumarFromString('+@tableColumn+')AS NUMERIC)) from '+@tableName +' where LEN(dbo.udf_GetNumarFromString('+@tableColumn+'))>0'
	
	IF ISNULL(@Filtru,'')!=''
	SET @StrString=@StrString+' AND '+@Filtru	
	
	EXEC(@StrString)  	
	END
		ELSE 
		Begin
			SELECT '-1';
			PRINT 'Tabelul nu contine coloana!'
		END
		
  END
     ELSE 
		Begin
			SELECT '-1';
			PRINT 'tabelul nu exista!'
		END
 END
 GO
 
IF ( NOT EXISTS ( SELECT    *
                  FROM      sys.objects
                  WHERE     object_id = OBJECT_ID(N'[dbo].[tblTransfer]')
                            AND type IN ( N'U' ) )
   )
    BEGIN
   
        CREATE TABLE [dbo].[tblTransfer]
            (
              [ID] [UNIQUEIDENTIFIER] NOT NULL ,
              [Data] [DATETIME] NOT NULL ,
              [LotBaseID] [UNIQUEIDENTIFIER] NOT NULL ,
              [CentruSursaID] [UNIQUEIDENTIFIER] NOT NULL ,
              [CentruDestinatieID] [UNIQUEIDENTIFIER] NOT NULL ,
              [ProduseID] [UNIQUEIDENTIFIER] NOT NULL ,
              [CantitateTransfer] [DECIMAL](18, 6) NOT NULL ,
              CONSTRAINT [PK_tblTransfer] PRIMARY KEY CLUSTERED ( [ID] ASC )
                WITH ( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,
                       IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
                       ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
            )
        ON  [PRIMARY];



        ALTER TABLE [dbo].[tblTransfer]  WITH CHECK ADD  CONSTRAINT [FK_tblTransfer_tblCentru] FOREIGN KEY([CentruDestinatieID])
        REFERENCES [dbo].[tblCentru] ([ID])


        ALTER TABLE [dbo].[tblTransfer] CHECK CONSTRAINT [FK_tblTransfer_tblCentru];


        ALTER TABLE [dbo].[tblTransfer]  WITH CHECK ADD  CONSTRAINT [FK_tblTransfer_tblCentru1] FOREIGN KEY([CentruSursaID])
        REFERENCES [dbo].[tblCentru] ([ID])


        ALTER TABLE [dbo].[tblTransfer] CHECK CONSTRAINT [FK_tblTransfer_tblCentru1];


        ALTER TABLE [dbo].[tblTransfer]  WITH CHECK ADD  CONSTRAINT [FK_tblTransfer_tblLotBase] FOREIGN KEY([LotBaseID])
        REFERENCES [dbo].[tblLotBase] ([ID])


        ALTER TABLE [dbo].[tblTransfer] CHECK CONSTRAINT [FK_tblTransfer_tblLotBase];


        ALTER TABLE [dbo].[tblTransfer]  WITH CHECK ADD  CONSTRAINT [FK_tblTransfer_tblProduse] FOREIGN KEY([ProduseID])
        REFERENCES [dbo].[tblProduse] ([ID])


        ALTER TABLE [dbo].[tblTransfer] CHECK CONSTRAINT [FK_tblTransfer_tblProduse]

    END
	    
IF NOT EXISTS ( SELECT  sc.name
                FROM    sys.objects so
                        INNER JOIN sys.columns sc ON so.object_id = sc.object_id
                WHERE   so.name = 'tblLotBase'
                        AND sc.name = 'TipCentruID' )
    BEGIN 
        ALTER TABLE dbo.tblLotBase ADD TipCentruID UNIQUEIDENTIFIER  NULL 
    
        ALTER TABLE [dbo].[tblLotBase]  WITH CHECK ADD  CONSTRAINT [FK_tblLotBase_tbxTipCentru] FOREIGN KEY([TipCentruID])
        REFERENCES [dbo].[tbxTipCentru] ([ID])
        ALTER TABLE [dbo].[tblLotBase] CHECK CONSTRAINT [FK_tblLotBase_tbxTipCentru]
    END
UPDATE dbo.tblNavigation SET Node='2' WHERE ID='bb20a662-f801-45ed-8164-ea201beddb2c'
UPDATE dbo.tblNavigation SET Node='3' WHERE ID='bc73dbe6-3dac-46c7-8c7b-4e8978dd8df6'
IF NOT EXISTS (SELECT ID FROM dbo.tblNavigation WHERE ID='D092C211-D88D-4E57-AC48-ED9EC694D019')
BEGIN
INSERT INTO dbo.tblNavigation
        ( ID ,
          Node ,
          NAME ,
          Description ,
          NavigateUrl ,
          Permission ,
          ParentGroupID ,
          PreCondition ,
          QueryString ,
          Title ,
          WindowString ,
          IsDialogWindow ,
          IsWeb ,
          IsWindow ,
          ModulID ,
          AplicatiiID ,
          ShortcutValue 
        )
VALUES  ( 'D092C211-D88D-4E57-AC48-ED9EC694D019' , -- ID - uniqueidentifier
          1 , -- Node - int
          'Acord Cadru' , -- NAME - varchar(100)
          'Acord Cadru' , -- Description - varchar(255)
          NULL , -- NavigateUrl - varchar(1024)
          '0' , -- Permission - varchar(255)
          '435f694f-2473-4c4b-8626-184c1941f3b3' , -- ParentGroupID - uniqueidentifier
          NULL , -- PreCondition - varchar(255)
          NULL , -- QueryString - varchar(255)
          'Acord Cadru' , -- Title - varchar(100)
          'ComenziGUI.AcordCadru, ComenziGUI' , -- WindowString - varchar(255)
          1 , -- IsDialogWindow - bit
          0 , -- IsWeb - bit
          0 , -- IsWindow - bit
          '2c191486-60af-41bc-b70e-fa8381f1f77e' , -- ModulID - uniqueidentifier
          '16eeff75-d7b1-4af5-8b01-e2b8d786f765' , -- AplicatiiID - uniqueidentifier
          NULL  -- ShortcutValue - varchar(50)
         
        )
END
GO
IF ( NOT EXISTS ( SELECT    *
                  FROM      sys.objects
                  WHERE     object_id = OBJECT_ID(N'[dbo].[tblAcordCadru]')
                            AND type IN ( N'U' ) )
   )
    BEGIN
        CREATE TABLE [dbo].[tblAcordCadru]
            (
              [ID] [UNIQUEIDENTIFIER] NOT NULL ,
              [Denumire] [NVARCHAR](500) NOT NULL ,
              [PartenerID] [UNIQUEIDENTIFIER] NOT NULL ,
              [DataStart] [DATETIME] NOT NULL ,
              [DataStop] [DATETIME] NOT NULL ,
              [TipCentruID] [UNIQUEIDENTIFIER] NOT NULL ,
              CONSTRAINT [PK_tblAcordCadru] PRIMARY KEY CLUSTERED ( [ID] ASC )
                WITH ( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,
                       IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
                       ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
            )
        ON  [PRIMARY];



        ALTER TABLE [dbo].[tblAcordCadru]  WITH CHECK ADD  CONSTRAINT [FK_tblAcordCadru_tblPartener] FOREIGN KEY([PartenerID])
        REFERENCES [dbo].[tblPartener] ([ID]);


        ALTER TABLE [dbo].[tblAcordCadru] CHECK CONSTRAINT [FK_tblAcordCadru_tblPartener];


        ALTER TABLE [dbo].[tblAcordCadru]  WITH CHECK ADD  CONSTRAINT [FK_tblAcordCadru_tbxTipCentru] FOREIGN KEY([TipCentruID])
        REFERENCES [dbo].[tbxTipCentru] ([ID]);


        ALTER TABLE [dbo].[tblAcordCadru] CHECK CONSTRAINT [FK_tblAcordCadru_tbxTipCentru];

    END;
GO
IF ( NOT EXISTS ( SELECT    *
                  FROM      sys.objects
                  WHERE     object_id = OBJECT_ID(N'[dbo].[tblAcordCadruDet]')
                            AND type IN ( N'U' ) )
   )
    BEGIN
      
        CREATE TABLE [dbo].[tblAcordCadruDet]
            (
              [ID] [UNIQUEIDENTIFIER] NOT NULL ,
              [AcordCadruID] [UNIQUEIDENTIFIER] NOT NULL ,
              [ProduseID] [UNIQUEIDENTIFIER] NOT NULL ,
              [Cantitate] [DECIMAL](18, 6) NOT NULL ,
              [Valoare] [DECIMAL](18, 6) NOT NULL ,
              [ValoareTVA] [DECIMAL](18, 6) NOT NULL ,
              CONSTRAINT [PK_tblAcordCadruDet] PRIMARY KEY CLUSTERED
                ( [ID] ASC )
                WITH ( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,
                       IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
                       ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
            )
        ON  [PRIMARY];

        ALTER TABLE [dbo].[tblAcordCadruDet]  WITH CHECK ADD  CONSTRAINT [FK_tblAcordCadruDet_tblAcordCadruDet] FOREIGN KEY([ProduseID])
        REFERENCES [dbo].[tblProduse] ([ID]);
        ALTER TABLE [dbo].[tblAcordCadruDet] CHECK CONSTRAINT [FK_tblAcordCadruDet_tblAcordCadruDet];


    END;
GO
IF NOT EXISTS ( SELECT  sc.name
                FROM    sys.objects so
                        INNER JOIN sys.columns sc ON so.object_id = sc.object_id
                WHERE   so.name = 'tblLotBase'
                        AND sc.name = 'AcordCadruID' )
    BEGIN 
        ALTER TABLE dbo.tblLotBase ADD AcordCadruID UNIQUEIDENTIFIER  NULL 
    
        ALTER TABLE [dbo].[tblLotBase]  WITH CHECK ADD  CONSTRAINT [FK_tblLotBase_tblAcordCadru] FOREIGN KEY([AcordCadruID])
        REFERENCES [dbo].[tblAcordCadru] ([ID])
        ALTER TABLE [dbo].[tblLotBase] CHECK CONSTRAINT [FK_tblLotBase_tblAcordCadru]
    END

	
IF NOT EXISTS ( SELECT  sc.name
                FROM    sysobjects so
                        INNER JOIN syscolumns sc ON so.id = sc.id
                WHERE   ( so.name = 'tblLotBase' )
                        AND ( sc.name = 'DataStop' ) )
    BEGIN
        ALTER TABLE dbo.tblLotBase ADD  DataStop DATETIME NULL; 
    END; 
GO

--===================================================================================
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
--===================================================================================
IF EXISTS
(
    SELECT *
    FROM sysobjects
    WHERE type = 'P'
          AND name = 'usp_GetComenziHome'
)
BEGIN
    DROP PROCEDURE usp_GetComenziHome;
END;

GO

CREATE PROCEDURE usp_GetComenziHome
    @pCentruID UNIQUEIDENTIFIER,
    @pDataLucru DATETIME
AS
BEGIN
    SELECT dbo.tblComandaBase.ID AS ID,
           tblComandaBase.LotID,
           dbo.tblComandaBase.Data,
           dbo.tblLotBase.Denumire,
           dbo.tblProduse.ID AS ProdusId,
           dbo.tblProduse.Cod AS CodProdus,
           dbo.tblProduse.Denumire AS DenumireProdus,
           CantitateDistribuita + ISNULL(
                                  (
                                      SELECT SUM(A.CantitateTransfer)
                                      FROM dbo.tblTransfer A
                                      WHERE A.CentruDestinatieID = @pCentruID
                                            AND A.LotBaseID = dbo.tblDistribuireLot.LotBaseID
                                            AND A.ProduseID = dbo.tblProduse.ID
                                  ),
                                  0
                                        ) - ISNULL(
                                            (
                                                SELECT SUM(A.CantitateTransfer)
                                                FROM dbo.tblTransfer A
                                                WHERE A.CentruSursaID = @pCentruID
                                                      AND A.LotBaseID = dbo.tblDistribuireLot.LotBaseID
                                                      AND A.ProduseID = dbo.tblProduse.ID
                                            ),
                                            0
                                                  ) AS CantitateDistribuita,
           CAST(NULL AS DECIMAL(18, 6)) AS CantitateComandata,
           CAST(NULL AS DECIMAL(18, 6)) AS CantitateDisponibilaLot,
           CAST(NULL AS DECIMAL(18, 6)) AS CantitateReceptionata,
           CAST(NULL AS DECIMAL(18, 6)) AS CantitateDispComanda,
           dbo.tblProduse.Pret,
           dbo.tblProduse.CotaTVAID,
           CAST(NULL AS DECIMAL(18, 6)) AS Valoare,
           CAST(NULL AS DECIMAL(18, 6)) AS ValoareTVA,
           CAST(NULL AS DECIMAL(18, 6)) AS ValoareCuTVA
    INTO #tmpComenzi
    FROM dbo.tblDistribuireLot
        INNER JOIN dbo.tblLotBase
            ON dbo.tblDistribuireLot.LotBaseID = dbo.tblLotBase.ID
        INNER JOIN dbo.tblComandaBase
            ON dbo.tblLotBase.ID = dbo.tblComandaBase.LotID
        INNER JOIN dbo.tblDistribuireLotDet
            ON dbo.tblDistribuireLot.ID = dbo.tblDistribuireLotDet.DistribuireLotID
        INNER JOIN dbo.tblProduse
            ON dbo.tblDistribuireLotDet.ProduseID = dbo.tblProduse.ID
    WHERE dbo.tblComandaBase.CentruID = @pCentruID
          AND dbo.tblDistribuireLot.CentruID = @pCentruID
          AND YEAR(tblComandaBase.Data) = YEAR(@pDataLucru)
    GROUP BY LotID,
             dbo.tblComandaBase.Data,
             dbo.tblComandaBase.ID,
             tblDistribuireLot.LotBaseID,
             tblDistribuireLotDet.CantitateDistribuita,
             dbo.tblLotBase.Denumire,
             dbo.tblProduse.Cod,
             dbo.tblProduse.Denumire,
             dbo.tblProduse.Pret,
             dbo.tblProduse.CotaTVAID,
             dbo.tblProduse.ID
    UNION ALL
    SELECT dbo.tblComandaBase.ID AS ID,
           tblComandaBase.LotID,
           dbo.tblComandaBase.Data,
           dbo.tblLotBase.Denumire,
           dbo.tblProduse.ID AS ProdusId,
           dbo.tblProduse.Cod AS CodProdus,
           dbo.tblProduse.Denumire AS DenumireProdus,
           CantitateTransfer AS CantitateDistribuita,
           CAST(NULL AS DECIMAL(18, 6)) AS CantitateComandata,
           CAST(NULL AS DECIMAL(18,6)) AS CantitateDisponibilaLot,
           CAST(NULL AS DECIMAL(18, 6)) AS CantitateReceptionata,
           CAST(NULL AS DECIMAL(18, 6)) AS CantitateDispComanda,
           dbo.tblProduse.Pret,
           dbo.tblProduse.CotaTVAID,
           CAST(NULL AS DECIMAL(18, 6)) AS Valoare,
           CAST(NULL AS DECIMAL(18, 6)) AS ValoareTVA,
           CAST(NULL AS DECIMAL(18, 6)) AS ValoareCuTVA
    FROM dbo.tblTransfer
        INNER JOIN dbo.tblLotBase
            ON tblLotBase.ID = tblTransfer.LotBaseID
        INNER JOIN dbo.tblProduse
            ON tblProduse.ID = tblTransfer.ProduseID
        INNER JOIN dbo.tblComandaBase
            ON tblComandaBase.LotID = dbo.tblTransfer.LotBaseID
               AND dbo.tblComandaBase.CentruID = dbo.tblTransfer.CentruDestinatieID
    WHERE dbo.tblTransfer.CentruDestinatieID = @pCentruID
          AND LotBaseID NOT IN
              (
                  SELECT LotBaseID FROM dbo.tblDistribuireLot WHERE CentruID = @pCentruID
              )
          AND YEAR(tblComandaBase.Data) = YEAR(@pDataLucru);


    UPDATE #tmpComenzi
    SET CantitateComandata =
        (
            SELECT ISNULL(
                   (
                       SELECT SUM(ISNULL(A.Cantitate, 0))
                       FROM dbo.tblComandaDet A
                       WHERE A.ComandaBaseID = #tmpComenzi.ID
                             AND A.ProduseID = #tmpComenzi.ProdusId
                   ),
                   0
                         )
        ),
        CantitateReceptionata = ISNULL(
                                (
                                    SELECT SUM(ISNULL(A.CantitateReceptionata, 0))
                                    FROM dbo.tblReceptieComandaDet A
                                        INNER JOIN dbo.tblReceptieComandaBase B
                                            ON B.ID = A.ReceptieComandaBaseID
                                    WHERE B.ComandaBaseID = #tmpComenzi.ID
                                          AND A.ProduseID = #tmpComenzi.ProdusId
                                ),
                                0
                                      ),
        CantitateDispComanda = ISNULL(
                               (
                                   SELECT SUM(ISNULL(A.Cantitate, 0))
                                   FROM dbo.tblComandaDet A
                                   WHERE A.ComandaBaseID = #tmpComenzi.ID
                                         AND A.ProduseID = #tmpComenzi.ProdusId
                               ),
                               0
                                     ) - ISNULL(
                                         (
                                             SELECT SUM(ISNULL(A.CantitateReceptionata, 0))
                                             FROM dbo.tblReceptieComandaDet A
                                                 INNER JOIN dbo.tblReceptieComandaBase B
                                                     ON A.ReceptieComandaBaseID = B.ID
                                             WHERE A.ProduseID = #tmpComenzi.ProdusId
                                                   AND B.ComandaBaseID = #tmpComenzi.ID
                                         ),
                                         0
                                               ),
        Valoare = ISNULL(
                  (
                      SELECT SUM(ISNULL(A.Cantitate, 0))
                      FROM dbo.tblComandaDet A
                      WHERE A.ComandaBaseID = #tmpComenzi.ID
                            AND A.ProduseID = #tmpComenzi.ProdusId
                  ),
                  0
                        ) * #tmpComenzi.Pret,
        ValoareTVA = ISNULL(
                     (
                         SELECT SUM(ISNULL(A.Cantitate, 0))
                         FROM dbo.tblComandaDet A
                         WHERE A.ComandaBaseID = #tmpComenzi.ID
                               AND A.ProduseID = #tmpComenzi.ProdusId
                     ),
                     0
                           ) * Pret * (ISNULL(
                                       (
                                           SELECT Valoare
                                           FROM dbo.tbxCotaTVA
                                           WHERE dbo.tbxCotaTVA.ID = #tmpComenzi.CotaTVAID
                                       ),
                                       0
                                             )
                                      ) / 100,
        ValoareCuTVA = ISNULL(
                       (
                           SELECT SUM(ISNULL(A.Cantitate, 0))
                           FROM dbo.tblComandaDet A
                           WHERE A.ComandaBaseID = #tmpComenzi.ID
                                 AND A.ProduseID = #tmpComenzi.ProdusId
                       ),
                       0
                             ) * Pret + ISNULL(
                                        (
                                            SELECT SUM(ISNULL(A.Cantitate, 0))
                                            FROM dbo.tblComandaDet A
                                            WHERE A.ComandaBaseID = #tmpComenzi.ID
                                                  AND A.ProduseID = #tmpComenzi.ProdusId
                                        ),
                                        0
                                              ) * Pret * (ISNULL(
                                                          (
                                                              SELECT Valoare
                                                              FROM dbo.tbxCotaTVA
                                                              WHERE dbo.tbxCotaTVA.ID = #tmpComenzi.CotaTVAID
                                                          ),
                                                          0
                                                                )
                                                         ) / 100;

    SELECT ID,
           LotID,
           Data,
           Denumire,
           CodProdus,
           DenumireProdus,
           SUM(#tmpComenzi.CantitateDistribuita) AS CantitateDistribuita,
           CantitateComandata,
           SUM(#tmpComenzi.CantitateDistribuita) -
           (
               SELECT SUM(A.CantitateComandata)
               FROM #tmpComenzi A
               WHERE A.Data <= #tmpComenzi.Data
                     AND A.CodProdus = #tmpComenzi.CodProdus
                     AND A.LotID = #tmpComenzi.LotID
           ) AS CantitateDisponibilaLot,
           CantitateReceptionata,
           CantitateDispComanda,
           #tmpComenzi.Pret,
           Valoare,
           ValoareTVA,
           ValoareCuTVA
    FROM #tmpComenzi
    GROUP BY ID,
             LotID,
             Data,
             Denumire,
             CodProdus,
             DenumireProdus,
             CantitateComandata,
             CantitateReceptionata,
             CantitateDispComanda,
             #tmpComenzi.Pret,
             Valoare,
             ValoareTVA,
             ValoareCuTVA;
END;

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
IF EXISTS
(
    SELECT *
    FROM sysobjects
    WHERE type = 'TR'
          AND name = 'tr_InsUpdDel_tblReceptieComandaDet_tblReceptieComandaDetAudit'
)
BEGIN
    DROP TRIGGER tr_InsUpdDel_tblReceptieComandaDet_tblReceptieComandaDetAudit;
END;
GO

CREATE TRIGGER tr_InsUpdDel_tblReceptieComandaDet_tblReceptieComandaDetAudit
ON dbo.tblReceptieComandaDet
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @DBName NVARCHAR(250);
    DECLARE @groupId NVARCHAR(36);
    SET @DBName =
    (
        SELECT DB_NAME() + '_Audit.dbo.tblReceptieComandaDetAudit'
    );
    SET @groupId = NEWID();


    SELECT i.*,
           dbo.tblProduse.Denumire AS Produse
    INTO #tempDeleted
    FROM Deleted i
        INNER JOIN dbo.tblProduse
            ON tblProduse.ID = i.ProduseID;

    SELECT i.*,
           dbo.tblProduse.Denumire AS Produse
    INTO #tempInserted
    FROM Inserted i
        INNER JOIN dbo.tblProduse
            ON tblProduse.ID = i.ProduseID;
    SELECT #tempDeleted.*
    INTO #tempMultipleRows
    FROM #tempInserted
        INNER JOIN #tempDeleted
            ON #tempDeleted.ID = #tempInserted.ID
    WHERE NOT EXISTS
    (
        SELECT #tempInserted.* EXCEPT SELECT #tempDeleted.*
    );
    DELETE #tempDeleted
    WHERE #tempDeleted.ID IN
          (
              SELECT ID FROM #tempMultipleRows
          );

    DELETE #tempInserted
    WHERE #tempInserted.ID IN
          (
              SELECT ID FROM #tempMultipleRows
          );

    SELECT #tempDeleted.ID
    INTO #tempUpdate
    FROM #tempInserted
        INNER JOIN #tempDeleted
            ON #tempInserted.ID = #tempDeleted.ID;

    DECLARE @UserName NVARCHAR(100);
    DECLARE @statie NVARCHAR(100);
    PRINT (CHARINDEX('&', APP_NAME()));
    IF CHARINDEX('&', APP_NAME()) > 0
    BEGIN
        SET @UserName = SUBSTRING(APP_NAME(), 1, CHARINDEX('&', APP_NAME()) - 1);
        SET @statie = SUBSTRING(APP_NAME(), CHARINDEX('&', APP_NAME()) + 1, LEN(APP_NAME()));
    END;
    ELSE
    BEGIN
        SET @UserName = APP_NAME();
        SET @statie = HOST_NAME();
    END;

    DECLARE @operatie NVARCHAR(2);
    SET @operatie = N'O';
    EXEC ('INSERT INTO  ' + @DBName + '(      GrupID, ReceptieComandaDetID,ReceptieComandaBaseID,ProduseID,Produse,CantitateReceptionata, UserName,Statie,DataAct,Operatie)
	SELECT   ''' + @groupId + ''',    ID, ReceptieComandaBaseID,ProduseID,Produse,CantitateReceptionata,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempDeleted
	where #tempDeleted.ID in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'U';
    EXEC ('INSERT INTO  ' + @DBName + '(      GrupID, ReceptieComandaDetID,ReceptieComandaBaseID,ProduseID,Produse,CantitateReceptionata, UserName,Statie,DataAct,Operatie)
	SELECT   ''' + @groupId + ''',    ID, ReceptieComandaBaseID,ProduseID,Produse,CantitateReceptionata,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempInserted
	where #tempInserted.ID in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'I';
    EXEC ('INSERT INTO  ' + @DBName + '(      GrupID, ReceptieComandaDetID,ReceptieComandaBaseID,ProduseID,Produse,CantitateReceptionata, UserName,Statie,DataAct,Operatie)
	SELECT   ''' + @groupId + ''',    ID, ReceptieComandaBaseID,ProduseID,Produse,CantitateReceptionata,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempInserted
	where #tempInserted.ID not in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'D';
    EXEC ('INSERT INTO  ' + @DBName + '(      GrupID, ReceptieComandaDetID,ReceptieComandaBaseID,ProduseID,Produse,CantitateReceptionata, UserName,Statie,DataAct,Operatie)
	SELECT   ''' + @groupId + ''',    ID, ReceptieComandaBaseID,ProduseID,Produse,CantitateReceptionata,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempDeleted
	where #tempDeleted.ID not in (select #tempUpdate.ID from #tempUpdate)');

END;

GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
IF EXISTS
(
    SELECT *
    FROM sysobjects
    WHERE type = 'TR'
          AND name = 'tr_InsUpdDel_tblReceptieComandaBase_tblReceptieComandaBaseAudit'
)
BEGIN
    DROP TRIGGER tr_InsUpdDel_tblReceptieComandaBase_tblReceptieComandaBaseAudit;
END;
GO

CREATE TRIGGER tr_InsUpdDel_tblReceptieComandaBase_tblReceptieComandaBaseAudit
ON dbo.tblReceptieComandaBase
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @DBName NVARCHAR(250);
    DECLARE @groupId NVARCHAR(36);
    SET @DBName =
    (
        SELECT DB_NAME() + '_Audit.dbo.tblReceptieComandaBaseAudit'
    );
    SET @groupId = NEWID();


    SELECT i.*
    INTO #tempDeleted
    FROM Deleted i
       
    SELECT i.*
    INTO #tempInserted
    FROM Inserted i
    SELECT #tempDeleted.*
    INTO #tempMultipleRows
    FROM #tempInserted
        INNER JOIN #tempDeleted
            ON #tempDeleted.ID = #tempInserted.ID
    WHERE NOT EXISTS
    (
        SELECT #tempInserted.* EXCEPT SELECT #tempDeleted.*
    );
    DELETE #tempDeleted
    WHERE #tempDeleted.ID IN
          (
              SELECT ID FROM #tempMultipleRows
          );

    DELETE #tempInserted
    WHERE #tempInserted.ID IN
          (
              SELECT ID FROM #tempMultipleRows
          );

    SELECT #tempDeleted.ID
    INTO #tempUpdate
    FROM #tempInserted
        INNER JOIN #tempDeleted
            ON #tempInserted.ID = #tempDeleted.ID;

    DECLARE @UserName NVARCHAR(100);
    DECLARE @statie NVARCHAR(100);
    PRINT (CHARINDEX('&', APP_NAME()));
    IF CHARINDEX('&', APP_NAME()) > 0
    BEGIN
        SET @UserName = SUBSTRING(APP_NAME(), 1, CHARINDEX('&', APP_NAME()) - 1);
        SET @statie = SUBSTRING(APP_NAME(), CHARINDEX('&', APP_NAME()) + 1, LEN(APP_NAME()));
    END;
    ELSE
    BEGIN
        SET @UserName = APP_NAME();
        SET @statie = HOST_NAME();
    END;

    DECLARE @operatie NVARCHAR(2);
    SET @operatie = N'O';
    EXEC ('INSERT INTO  ' + @DBName + '(  GrupID,ReceptieComandaBaseID,NumarFactura,NumarNir,DataReceptie, ComandaBaseID, UserName, Statie, DataAct, Operatie)
	SELECT   ''' + @groupId + ''',    ID, NumarFactura,NumarNir,DataReceptie, ComandaBaseID,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempDeleted
	where #tempDeleted.ID in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'U';
        EXEC ('INSERT INTO  ' + @DBName + '(  GrupID,ReceptieComandaBaseID,NumarFactura,NumarNir,DataReceptie, ComandaBaseID, UserName, Statie, DataAct, Operatie)
	SELECT   ''' + @groupId + ''',    ID, NumarFactura,NumarNir,DataReceptie, ComandaBaseID,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempInserted
	where #tempInserted.ID in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'I';
    EXEC ('INSERT INTO  ' + @DBName + '(  GrupID,ReceptieComandaBaseID,NumarFactura,NumarNir,DataReceptie, ComandaBaseID, UserName, Statie, DataAct, Operatie)
	SELECT   ''' + @groupId + ''',    ID, NumarFactura,NumarNir,DataReceptie, ComandaBaseID,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempInserted
	where #tempInserted.ID not in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'D';
    EXEC ('INSERT INTO  ' + @DBName + '(  GrupID,ReceptieComandaBaseID,NumarFactura,NumarNir,DataReceptie, ComandaBaseID, UserName, Statie, DataAct, Operatie)
	SELECT   ''' + @groupId + ''',    ID, NumarFactura,NumarNir,DataReceptie, ComandaBaseID,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempDeleted
	where #tempDeleted.ID not in (select #tempUpdate.ID from #tempUpdate)');

END;

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

IF EXISTS
(
    SELECT *
    FROM sysobjects
    WHERE type = 'TR'
          AND name = 'tr_InsUpdDel_tblComandaDet_tblComandaDetAudit'
)
BEGIN
    DROP TRIGGER tr_InsUpdDel_tblComandaDet_tblComandaDetAudit;
END;
GO

CREATE TRIGGER tr_InsUpdDel_tblComandaDet_tblComandaDetAudit
ON dbo.tblComandaDet
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DBName NVARCHAR(250);
    DECLARE @groupId NVARCHAR(36);
    SET @DBName =
    (
        SELECT DB_NAME() + '_Audit.dbo.tblComandaDetAudit'
    );
    SET @groupId = NEWID();


    SELECT i.*,
           dbo.tblProduse.Denumire AS Produse
    INTO #tempDeleted
    FROM Deleted i
        INNER JOIN dbo.tblProduse
            ON tblProduse.ID = i.ProduseID;


    SELECT i.*,
           dbo.tblProduse.Denumire AS Produse
    INTO #tempInserted
    FROM Inserted i
        INNER JOIN dbo.tblProduse
            ON tblProduse.ID = i.ProduseID;
    SELECT #tempDeleted.*
    INTO #tempMultipleRows
    FROM #tempInserted
        INNER JOIN #tempDeleted
            ON #tempDeleted.ID = #tempInserted.ID
    WHERE NOT EXISTS
    (
        SELECT #tempInserted.* EXCEPT SELECT #tempDeleted.*
    );
    DELETE #tempDeleted
    WHERE #tempDeleted.ID IN
          (
              SELECT ID FROM #tempMultipleRows
          );

    DELETE #tempInserted
    WHERE #tempInserted.ID IN
          (
              SELECT ID FROM #tempMultipleRows
          );

    SELECT #tempDeleted.ID
    INTO #tempUpdate
    FROM #tempInserted
        INNER JOIN #tempDeleted
            ON #tempInserted.ID = #tempDeleted.ID;

    DECLARE @UserName NVARCHAR(100);
    DECLARE @statie NVARCHAR(100);
    PRINT (CHARINDEX('&', APP_NAME()));
    IF CHARINDEX('&', APP_NAME()) > 0
    BEGIN
        SET @UserName = SUBSTRING(APP_NAME(), 1, CHARINDEX('&', APP_NAME()) - 1);
        SET @statie = SUBSTRING(APP_NAME(), CHARINDEX('&', APP_NAME()) + 1, LEN(APP_NAME()));
    END;
    ELSE
    BEGIN
        SET @UserName = APP_NAME();
        SET @statie = HOST_NAME();
    END;

    DECLARE @operatie NVARCHAR(2);
    SET @operatie = N'O';
    EXEC ('INSERT INTO  ' + @DBName + '(GrupID,ComandaDetID,ComandaBaseID,ProduseID,Produse, Cantitate, Valoare, ValoareTVA,UserName, Statie, DataAct,Operatie)
	SELECT   ''' + @groupId + ''',    ID, ComandaBaseID,ProduseID,Produse, Cantitate, Valoare, ValoareTVA,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempDeleted
	where #tempDeleted.ID in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'U';
    EXEC ('INSERT INTO  ' + @DBName + '(GrupID,ComandaDetID,ComandaBaseID,ProduseID,Produse, Cantitate, Valoare, ValoareTVA,UserName, Statie, DataAct,Operatie)
	SELECT   ''' + @groupId + ''',    ID, ComandaBaseID,ProduseID,Produse, Cantitate, Valoare, ValoareTVA,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempInserted
	where #tempInserted.ID in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'I';
    EXEC ('INSERT INTO  ' + @DBName + '(GrupID,ComandaDetID,ComandaBaseID,ProduseID,Produse, Cantitate, Valoare, ValoareTVA,UserName, Statie, DataAct,Operatie)
	SELECT   ''' + @groupId + ''',    ID, ComandaBaseID,ProduseID,Produse, Cantitate, Valoare, ValoareTVA,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempInserted
	where #tempInserted.ID not in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'D';
    EXEC ('INSERT INTO  ' + @DBName + '(GrupID,ComandaDetID,ComandaBaseID,ProduseID,Produse, Cantitate, Valoare, ValoareTVA,UserName, Statie, DataAct,Operatie)
	SELECT   ''' + @groupId + ''',    ID, ComandaBaseID,ProduseID,Produse, Cantitate, Valoare, ValoareTVA,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempDeleted
	where #tempDeleted.ID not in (select #tempUpdate.ID from #tempUpdate)');

END;

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

IF EXISTS
(
    SELECT *
    FROM sysobjects
    WHERE type = 'TR'
          AND name = 'tr_InsUpdDel_tblComandaBase_tblComandaBaseAudit'
)
BEGIN
    DROP TRIGGER tr_InsUpdDel_tblComandaBase_tblComandaBaseAudit;
END;
GO

CREATE TRIGGER tr_InsUpdDel_tblComandaBase_tblComandaBaseAudit
ON dbo.tblComandaBase
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DBName NVARCHAR(250);
    DECLARE @groupId NVARCHAR(36);
    SET @DBName =
    (
        SELECT DB_NAME() + '_Audit.dbo.tblComandaBaseAudit'
    );
    SET @groupId = NEWID();


    SELECT i.*,
           dbo.tblCentru.Denumire AS Centru,
           dbo.tblLotBase.Denumire AS Lot
    INTO #tempDeleted
    FROM Deleted i
        INNER JOIN dbo.tblLotBase
            ON tblLotBase.ID = i.LotID
        INNER JOIN dbo.tblCentru
            ON tblCentru.ID = i.CentruID;

    SELECT i.*,
           dbo.tblCentru.Denumire AS Centru,
           dbo.tblLotBase.Denumire AS Lot
    INTO #tempInserted
    FROM Inserted i
        INNER JOIN dbo.tblLotBase
            ON tblLotBase.ID = i.LotID
        INNER JOIN dbo.tblCentru
            ON tblCentru.ID = i.CentruID;
    SELECT #tempDeleted.*
    INTO #tempMultipleRows
    FROM #tempInserted
        INNER JOIN #tempDeleted
            ON #tempDeleted.ID = #tempInserted.ID
    WHERE NOT EXISTS
    (
        SELECT #tempInserted.* EXCEPT SELECT #tempDeleted.*
    );
    DELETE #tempDeleted
    WHERE #tempDeleted.ID IN
          (
              SELECT ID FROM #tempMultipleRows
          );

    DELETE #tempInserted
    WHERE #tempInserted.ID IN
          (
              SELECT ID FROM #tempMultipleRows
          );

    SELECT #tempDeleted.ID
    INTO #tempUpdate
    FROM #tempInserted
        INNER JOIN #tempDeleted
            ON #tempInserted.ID = #tempDeleted.ID;

    DECLARE @UserName NVARCHAR(100);
    DECLARE @statie NVARCHAR(100);
    PRINT (CHARINDEX('&', APP_NAME()));
    IF CHARINDEX('&', APP_NAME()) > 0
    BEGIN
        SET @UserName = SUBSTRING(APP_NAME(), 1, CHARINDEX('&', APP_NAME()) - 1);
        SET @statie = SUBSTRING(APP_NAME(), CHARINDEX('&', APP_NAME()) + 1, LEN(APP_NAME()));
    END;
    ELSE
    BEGIN
        SET @UserName = APP_NAME();
        SET @statie = HOST_NAME();
    END;

    DECLARE @operatie NVARCHAR(2);
    SET @operatie = N'O';
    EXEC ('INSERT INTO  ' + @DBName + '( GrupID, ComandaID, LotID, Lot, Data,CentruID,
    Centru, UserName, Statie, DataAct, Operatie)
	SELECT   ''' + @groupId + ''',    ID, LotID, Lot,Data, CentruID, Centru,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempDeleted
	where #tempDeleted.ID in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'U';
    EXEC ('INSERT INTO  ' + @DBName + '( GrupID, ComandaID, LotID, Lot, Data,CentruID,
    Centru, UserName, Statie, DataAct, Operatie)
	SELECT   ''' + @groupId + ''',    ID, LotID, Lot,Data, CentruID, Centru,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempInserted
	where #tempInserted.ID in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'I';
    EXEC ('INSERT INTO  ' + @DBName + '( GrupID, ComandaID, LotID, Lot, Data,CentruID,
    Centru, UserName, Statie, DataAct, Operatie)
	SELECT   ''' + @groupId + ''',    ID, LotID, Lot,Data, CentruID, Centru,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempInserted
	where #tempInserted.ID not in (select #tempUpdate.ID from #tempUpdate)');

    SET @operatie = N'D';
    EXEC ('INSERT INTO  ' + @DBName + '( GrupID, ComandaID, LotID, Lot, Data,CentruID,
    Centru, UserName, Statie, DataAct, Operatie)
	SELECT   ''' + @groupId + ''',    ID, LotID, Lot,Data, CentruID, Centru,	
			 ''' + @UserName + ''',''' + @statie + ''',GETDATE(),''' + @operatie + '''
	FROM  #tempDeleted
	where #tempDeleted.ID not in (select #tempUpdate.ID from #tempUpdate)');

END;