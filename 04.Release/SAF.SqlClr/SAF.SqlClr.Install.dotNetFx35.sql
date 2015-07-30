﻿--脚本安装SAF.SqlClr

DECLARE @DatabaseName NVARCHAR(50),@sql NVARCHAR(2000)
SELECT @DatabaseName=DB_NAME()

PRINT N'设置数据库兼容性...';
SET @sql='IF EXISTS (SELECT  TOP 1 1
			FROM    sys.databases A WITH ( NOLOCK )
			WHERE A.name='''+@DatabaseName+'''
			AND A.compatibility_level<100)
			ALTER DATABASE '+@DatabaseName+'
			SET COMPATIBILITY_LEVEL = 100
			'
EXEC(@sql)


PRINT N'开启数据库SQLCLR支持...';

--启用clr(1为启用，0为关闭)
EXEC sp_configure 'clr enabled',1
--执行以上语句会有提示:请运行RECONFIGURE语句进行安装
RECONFIGURE WITH OVERRIDE
--B.修改执行权限
SET @sql='ALTER DATABASE '+@DatabaseName+' SET TRUSTWORTHY ON'
EXEC(@sql)
GO

--删除列绑定
PRINT N'正在取消表 [dbo].[sysMenu] 中ConvertToPinyin的列绑定...';
GO
ALTER TABLE [dbo].[sysMenu] DROP COLUMN [Pinyin];
GO

PRINT N'正在删除 [dbo].[CalcValue]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='CalcValue')
DROP AGGREGATE [dbo].[CalcValue];
GO

PRINT N'正在删除 [dbo].[ConcatString]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='ConcatString')
DROP AGGREGATE [dbo].[ConcatString];
GO

PRINT N'正在删除 [dbo].[PadLeft]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='PadLeft')
DROP FUNCTION [dbo].[PadLeft];
GO

PRINT N'正在删除 [dbo].[PadRight]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='PadRight')
DROP FUNCTION [dbo].[PadRight];
GO

PRINT N'正在删除 [dbo].[ConvertMoneyToCN]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='ConvertMoneyToCN')
DROP FUNCTION [dbo].[ConvertMoneyToCN];
GO

PRINT N'正在删除 [dbo].[ConvertMoneyToEN]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='ConvertMoneyToEN')
DROP FUNCTION [dbo].[ConvertMoneyToEN];
GO

PRINT N'正在删除 [dbo].[ConvertToProperCase]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='ConvertToProperCase')
DROP FUNCTION [dbo].[ConvertToProperCase];
GO

PRINT N'正在删除 [dbo].[ConvertToSimplifiedChinese]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='ConvertToSimplifiedChinese')
DROP FUNCTION [dbo].[ConvertToSimplifiedChinese];
GO

PRINT N'正在删除 [dbo].[ConvertToTraditionalChinese]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='ConvertToTraditionalChinese')
DROP FUNCTION [dbo].[ConvertToTraditionalChinese];
GO

PRINT N'正在删除 [dbo].[ConvertToPinyin]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='ConvertToPinyin')
DROP FUNCTION [dbo].[ConvertToPinyin];
GO

PRINT N'正在删除 [dbo].[SplitString]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='SplitString')
DROP FUNCTION [dbo].[SplitString];
GO

PRINT N'正在删除 [dbo].[Dual]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.sysobjects where name='Dual')
DROP FUNCTION [dbo].[Dual];
GO

PRINT N'正在删除 [SAF.SqlClr]...';
GO
IF EXISTS(SELECT TOP 1 1 FROM sys.assemblies WHERE name='SAF.SqlClr')
DROP ASSEMBLY [SAF.SqlClr];
GO

PRINT N'正在创建 [SAF.SqlClr]...';
GO
CREATE ASSEMBLY [SAF.SqlClr]
    AUTHORIZATION [dbo]
    FROM 0x4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C0103000048AF550000000000000000E00002210B010B00002A00000006000000000000BE48000000200000006000000000001000200000000200000400000000000000040000000000000000A000000002000000000000030040850000100000100000000010000010000000000000100000000000000000000000644800005700000000600000B803000000000000000000000000000000000000008000000C0000002C4700001C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E74657874000000C428000000200000002A000000020000000000000000000000000000200000602E72737263000000B80300000060000000040000002C0000000000000000000000000000400000402E72656C6F6300000C0000000080000000020000003000000000000000000000000000004000004200000000000000000000000000000000A0480000000000004800000002000500D42F00005817000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001B300500FE01000001000011022C3302280E00000A2D2B026F0F00000A7201000070281000000A2D1902281100000A18281200000A16731300000A281400000A2C0672050000702A02178D1E00000113091109161F2E9D11096F1500000A0A020B72090000700C72090000700D068E6917310806169A0B06179A0C08720B000070281600000A0C0816186F1700000A0C0708281600000A0B076F1800000A175913041104163E4A01000011041F123C4101000016130738C40000000711076F1900000A1F305913051107175811042F0F07110717586F1900000A1F30592B0B0711046F1900000A1F3059130611052D5D1104110759182E1A11041107591C2E1211041107591F0A2E0911041107591F0E331D097E0200000411041107596F1900000A8C1E000001281A00000A0D2B4A11062C46097E0100000411056F1900000A8C1E000001281A00000A0D2B2C097E0100000411056F1900000A8C1E0000017E0200000411041107596F1900000A8C1E000001281B00000A0D110717581307110711043E33FFFFFF09721100007072190000706F1C00000A0D09721D00007072190000706F1C00000A0D09722300007072290000706F1C00000A0D09178D1E000001130A110A1620065700009D110A6F1D00000A0D09178D1E000001130B110B1620F69600009D110B6F1D00000A0D091308DE1372090000701308DE0A2672090000701308DE0011082A0000411C0000000000008C00000065010000F10100000A000000010000011B3004009903000002000011022C3302280E00000A2D2B026F0F00000A7201000070281000000A2D1902281100000A18281200000A16731300000A281400000A2C06722D0000702A02178D1E000001130E110E161F2E9D110E6F1500000A0A020B72090000700C72090000700D068E6917310806169A0B06179A0C08720B000070281600000A0C0816186F1700000A0C076F1800000A175913071107163F1F02000011071F0F3C1602000016130B38F90100007209000070130472090000701305720900007013061107183F030100000711071859196F1700000A281E00000A130C110C39B7010000110C1F645B1308110C11081F645A591F0A5B1309110C11081F645A5911091F0A5A59130A11082C147E0300000411089A7237000070281600000A130411092C51110917331C7E0300000411091F0A5A110A589A724B000070281600000A13052B487E04000004110918599A724B000070281600000A1305110A2C2E7E03000004110A9A724B000070281600000A13062B18110A2C147E03000004110A9A724B000070281600000A13061C8D1A000001130F110F161104A2110F171105A2110F181106A2110F197E05000004110B9AA2110F1A724B000070A2110F1B09A2110F281F00000A0D38CD0000000716110717586F1700000A281E00000A130C110C39B4000000110C1F0A5B1309110C11091F0A5A59130A11092C51110917331C7E0300000411091F0A5A110A589A724B000070281600000A13052B487E04000004110918599A724B000070281600000A1305110A2C2E7E03000004110A9A724B000070281600000A13062B18110A2C147E03000004110A9A724B000070281600000A13061B8D1A00000113101110161105A21110171106A21110187E05000004110B9AA2111019724B000070A211101A09A21110281F00000A0D110B1758130B1107195913071107163CFFFDFFFF09168D1E0000016F2000000A0D720900007013057209000070130608281E00000A130C110C39A8000000110C1F0A5B1309110C11091F0A5A59130A11092C51110917331C7E0300000411091F0A5A110A589A724B000070281600000A13052B487E04000004110918599A724B000070281600000A1305110A2C2E7E03000004110A9A724B000070281600000A13062B18110A2C147E03000004110A9A724B000070281600000A1306096F1800000A16311209724F00007011051106282100000A0D2B0F726700007011051106282200000A0D09168D1E0000016F2000000A0D09130DDE0A267209000070130DDE00110D2A000000411C00000000000084000000080300008C0300000A0000000100000113300300500100000300001172750000708001000004728B00007080020000041F148D1A0000010A06167209000070A2061772B1000070A2061872B9000070A2061972C1000070A2061A72CD000070A2061B72D7000070A2061C72E1000070A2061D72E9000070A2061E72F5000070A2061F097201010070A2061F0A720B010070A2061F0B7213010070A2061F0C7221010070A2061F0D722F010070A2061F0E7241010070A2061F0F7253010070A2061F107263010070A2061F117273010070A2061F127287010070A2061F137299010070A20680030000041E8D1A0000010B071672AB010070A2071772B9010070A2071872C7010070A2071972D3010070A2071A72DF010070A2071B72EB010070A2071C72FB010070A2071D7209020070A20780040000041B8D1A0000010C08167209000070A208177217020070A208187229020070A208197239020070A2081A7249020070A20880050000042A3E02167D0600000402177D070000042A1330040019020000040000110F01282600000A2C012A0F02282700000A2C012A027B070000042C15020F01282800000A7D0600000402167D070000042A0F02282900000A250A39D9010000FE137E0A0000043A870000001F0A732B00000A25725B02007016282C00000A25725F02007017282C00000A25726302007018282C00000A25726702007019282C00000A25726B0200701A282C00000A25726F0200701B282C00000A2572750200701C282C00000A25727B0200701D282C00000A25727F0200701E282C00000A2572830200701F09282C00000AFE13800A000004FE137E0A000004061201282D00000A393201000007450A00000001000000160000002B000000400000006B00000096000000AE000000C6000000DB000000F00000002A02257B060000040F01282800000A587D060000042A02257B060000040F01282800000A597D060000042A02257B060000040F01282800000A5A7D060000042A0316282E00000A282F00000A283000000A39AE00000002257B060000040F01282800000A5B7D060000042A0316282E00000A282F00000A283000000A398300000002257B060000040F01282800000A5D7D060000042A02257B060000040F01282800000A1F1F5F627D060000042A02257B060000040F01282800000A1F1F5F637D060000042A02257B060000040F01282800000A5F7D060000042A02257B060000040F01282800000A617D060000042A02257B060000040F01282800000A607D060000042A8A02257B060000040F017B06000004587D06000004020F017B070000047D070000042A32027B06000004733100000A2A4E02733200000A7D0800000402167D090000042A000000033002006200000000000000036F3300000A2C012A027B090000042D22020F02282700000A2D090F02282900000A2B0572870200706F1800000A7D09000004027B08000004036F3400000A6F3500000A0F02282700000A2D090F02282900000A2B0572870200706F3600000A262A52027B080000040F017B080000046F3700000A262A001330040047000000050000117E3800000A0A027B080000042C2D027B080000046F3900000A16311F027B0800000416027B080000046F3900000A027B09000004596F3A00000A0A06283B00000A733C00000A2A7A02036F3D00000A733E00000A7D0800000402036F3F00000A7D090000042A7A03027B080000046F4000000A6F4100000A03027B090000046F4200000A2A9E0F00284400000A2C067E4500000A2A0F00FE160A0000016F4000000A2801000006734600000A2A9E0F00284400000A2C067E4500000A2A0F00FE160A0000016F4000000A2802000006734600000A2A000000133003002900000005000011026F3300000A2C02022A026F3400000A734700000A0A061916284800000A283B00000A733C00000A2A000000133003002D00000005000011026F3300000A2C02022A026F3400000A734700000A0A06200001000016284800000A283B00000A733C00000A2A000000133003002D00000005000011026F3300000A2C02022A026F3400000A734700000A0A06200002000016284800000A283B00000A733C00000A2A000000133004006300000006000011160A0F00282600000A284900000A25283000000A2D110216282E00000A284A00000A284B00000A283000000A2C04160A2B080F00282800000A0A140B06163121068D1A0000010B160C2B1207080817580D1203284C00000AA20817580C080632EA072A56022C110302741A000001283B00000A81050000012A000000033003006100000000000000026F3300000A2C02022A0F01282600000A284900000A25283000000A2D110316282E00000A284A00000A284B00000A283000000A2C0816282E00000A1001026F3400000A734700000A0F01282800000A04284D00000A283B00000A733C00000A2A000000033003006100000000000000026F3300000A2C02022A0F01282600000A284900000A25283000000A2D110316282E00000A284A00000A284B00000A283000000A2C0816282E00000A1001026F3400000A734700000A0F01282800000A04284E00000A283B00000A733C00000A2A000000133004008000000007000011026F3300000A2C0D178D1A000001130411040A2B69036F3300000A2C20178D1A0000011305110516026F4F00000A13061206282900000AA211050A2B41026F4F00000A13071207282900000A0B036F4F00000A13081208282900000A0C08178D1E00000113091109161F7C9D1109176F5000000A0D0709176F5100000A0A062A56022C110302741A000001283B00000A81050000012A0000133001002700000005000011026F3300000A2C02022A026F3400000A734700000A0A06281B000006283B00000A733C00000A2A1E02285200000A2A00133004004C0000000800001102280E00000A2D0D026F0F00000A6F1800000A2D02022A026F1800000A0A06735300000A0B160C2B18070208176F1700000A281C0000066F3600000A260817580C080632E4076F4000000A2A00000000A1B00000C5B00000C1B20000EEB40000EAB60000A2B70000C1B80000FEB90000F7BB0000F7BB0000A6BF0000ACC00000E8C20000C3C40000B6C50000BEC50000DAC60000BBC80000F6C80000FACB0000DACD0000DACD0000DACD0000F4CE0000B9D10000D1D40000133005008F00000009000011285400000A026F5500000A0A068E6917317B0616910B0617910C071E6208580D1F1A8D1F00000125D00B000004285600000A13041613052B4820FAD70000130611051F192E0911041105175894130611041105940930240911062F1F285400000A178D3000000113071107161F41110558D29C11076F5700000A2A11051758130511051F1A32B2728B0200702A022A0042534A4201000100000000000C00000076322E302E35303732370000000005006C00000090070000237E0000FC0700007808000023537472696E67730000000074100000900200002355530004130000100000002347554944000000141300004404000023426C6F620000000000000002000001579702280902000000FA2533001600000100000030000000080000000B0000001C0000001F0000000100000057000000180000000100000009000000010000000100000001000000030000000100000000000A00010000000000060086007F0006008D007F000A00BE00A3000A00470132010A00500132010600810175010A00A50132010600B801AE010600CA01AE010A00DD01320106006602530206007403620306008B0362030600A80362030600C70362030600E00362030600F903620306001404620306002F046203060048046203060061046203060091047E045B00A50400000600D404B4040600F404B40406001D057F00060043057F0006004B057F0006005D057F00060068057F000600AB057F000600C6057F000A00DC05A3000A00FD05A30006002306040606003906040606009E06B4040600D406B9060A00110732010A005D07A3000E008D0777070E00950777070600CC077F000600DF07750106002F08B40406003E087F00060044087F00060067087F0000000000010000000000010001008001100019002800050001000100092110003A0000000900060004000921100044000000090008000800010010005100000005000A000E00810110006600280005000A001B00000000005906000005000A001D0013010000FD07000009000C001D003100CF000A003100D8000A003100DF000D003100ED000D003100FB000D0001001A01160001002501190001008F0133000100960116001300E106620113011B085503502000000000960002011100010078220000000096000E01110002003C26000000009118BF053501030098270000000086002D011C000300A8270000000086005A0120000300CD29000000008600650128000500F0290000000086006B012E000600FD290000000086002D011C000600142A0000000086005A0137000600822A00000000860065013F000800982A0000000086006B0145000900EB2A00000000E601C5014A0009000A2B00000000E601D70150000A00292B000000009600E60156000B00512B000000009600F70156000C007C2B00000000960008025D000D00B42B0000000096001C025D000E00F02B00000000960037025D000F002C2C0000000096007202640010009B2C00000000910077026B001100B42C000000009600830273001300242D0000000096008B0273001600942D00000000960094027D001900202E000000009100A0026B001B00382E000000009600AD025D001D006B2E000000008618BD021C001E00742E000000009600C30211001E00382F000000009100D30211001F0000000100E40200000100E40200000100F00200000200F60200000100FE0200000100F002000002000403000001000E03000001001403000001001B03000001002203000001002203000001002803000001002803000001002803000001002E03000001003403000002003803000001002803000002003D03000003004803000001002803000002003D03000003004803000001002803000002005403000001003403000002003803000001002803000001005D03000001005F0304000D006100BD0286006900BD0286007100BD0286007900BD0286008100BD0286008900BD0286009100BD0286009900BD028600A100BD028600A900BD028600B100BD028B00C100BD029100C900BD021C00D10024059600D10032059B00D10037059F00D9005305A500E9006205AB00E100BD029100E1003705B300D1006D05BB00D1007305C200D1007A05C800D1008405CE00D1008F05D200D1007305D700D1007305DD00D1009905E400D100A105EA00F900B1050301D10073050801D100B705EA00D10073050E01D100730516010101BD021C000901BD0242011901BD02520121004406590129004406590121004F06CE0029004F069B002901BD021C000C00BD0291000C00F50673010C00F9067B0121000507840121001C078A0139012A0794012100BD0291003100BD021C0039004406590139004F060202310032070702310032070E02310032071402D10039070A0031008405CE0031003F07C800290005071A023900BD022002410048079B003100BD02860041005307CE0009003F079B004900D70186004900D70191004101BD021C00510044065901290072072A022900BD028600D100BD022E0249019F073D0239010507A8022100A7078A013901B307AF02F9003F079B00D1008302C302D1008B02C3023900C0071403D1006D051903D1006D0523030900BD021C003100BD0291006101E80749036101F4074F0369015708590361016C0863032E0063001B042E006B0024042E005B0012042E000B0077032E00130077032E001B0087032E0023008D032E002B0077032E003300BD032E003B0087032E005300050463002301490183002301A001E30053015D01C0011B025D01E0011B025D0100021B025D0120021B02460240021B02460260021B025E02A0021B025D01C0021B025D01E0021B02C90220031B025D010100680000000800F0001D0139019B012602BB022D03420369036B01D02E00000B00048000000100000000000000000000000000120500000200000000000000000000000100760000000000020000000000000000000000010097000000000008000000000000000000000034027707000000000800070000000000003C4D6F64756C653E005341462E53716C436C722E646C6C004D6F6E6579436F6E766572746572005341462E53716C436C722E48656C7065720043616C6356616C756500436F6E636174537472696E670055736572446566696E656446756E6374696F6E7300537472696E67436F6E766572746572006D73636F726C69620053797374656D004F626A6563740056616C7565547970650053797374656D2E44617461004D6963726F736F66742E53716C5365727665722E536572766572004942696E61727953657269616C697A6500636E4E756D62657200636E556E697400656E536D616C6C4E756D62657200656E4C617267654E756D62657200656E556E697400476574436E537472696E6700476574456E537472696E6700746F74616C56616C7565006973466972737400496E69740053797374656D2E446174612E53716C54797065730053716C496E7433320053716C537472696E6700416363756D756C617465004D65726765005465726D696E6174650053797374656D2E5465787400537472696E674275696C64657200726573756C740073706C69747465724C656E6774680053716C43686172730053797374656D2E494F0042696E61727952656164657200526561640042696E6172795772697465720057726974650053716C4D6F6E657900436F6E766572744D6F6E6579546F434E00436F6E766572744D6F6E6579546F454E00436F6E76657274546F50726F7065724361736500436F6E76657274546F53696D706C69666965644368696E65736500436F6E76657274546F547261646974696F6E616C4368696E6573650053797374656D2E436F6C6C656374696F6E730049456E756D657261626C65004475616C004475616C46696C6C526F77005061644C6566740050616452696768740053706C6974537472696E670053706C697446696C6C526F7700436F6E76657274546F50696E79696E002E63746F72004765744368696E6573655370656C6C005F4765744368696E6573655370656C6C006D6F6E6579537472696E670076616C7565006F7065726174650047726F757000636F6E6E6563746F72006F746865720072656164657200777269746572006D6F6E657900696E70757400636F756E74006F626A006974656D00746F74616C57696474680070616464696E67436861720073706C6974746572007300636E0053797374656D2E5265666C656374696F6E00417373656D626C795469746C6541747472696275746500417373656D626C794465736372697074696F6E41747472696275746500417373656D626C79436F6E66696775726174696F6E41747472696275746500417373656D626C79436F6D70616E7941747472696275746500417373656D626C7950726F6475637441747472696275746500417373656D626C79436F7079726967687441747472696275746500417373656D626C7954726164656D61726B41747472696275746500417373656D626C7943756C7475726541747472696275746500417373656D626C7956657273696F6E41747472696275746500417373656D626C7946696C6556657273696F6E4174747269627574650053797374656D2E446961676E6F73746963730044656275676761626C6541747472696275746500446562756767696E674D6F6465730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300436F6D70696C6174696F6E52656C61786174696F6E734174747269627574650052756E74696D65436F6D7061746962696C697479417474726962757465005341462E53716C436C7200537472696E670049734E756C6C4F72456D707479005472696D006F705F457175616C69747900436F6E7665727400446563696D616C00546F446563696D616C004D61746800526F756E6400436861720053706C697400436F6E63617400537562737472696E67006765745F4C656E677468006765745F4368617273005265706C616365005472696D537461727400496E743332005061727365005472696D456E64002E6363746F720053657269616C697A61626C654174747269627574650053716C55736572446566696E656441676772656761746541747472696275746500466F726D61740053797374656D2E52756E74696D652E496E7465726F705365727669636573005374727563744C61796F7574417474726962757465004C61796F75744B696E64006765745F49734E756C6C006765745F56616C7565003C50726976617465496D706C656D656E746174696F6E44657461696C733E7B36443034333937312D433034392D343032322D384138342D3946324233463031453034447D00436F6D70696C657247656E6572617465644174747269627574650053797374656D2E436F6C6C656374696F6E732E47656E657269630044696374696F6E61727960320024246D6574686F643078363030303030342D31004164640054727947657456616C7565006F705F496D706C696369740053716C426F6F6C65616E006F705F496E657175616C697479006F705F5472756500417070656E6400456D70747900546F537472696E670052656164537472696E670052656164496E7433320053716C46756E6374696F6E417474726962757465004E756C6C004D6963726F736F66742E56697375616C426173696300537472696E6773005662537472436F6E7600537472436F6E76006F705F4C6573735468616E006F705F426974776973654F7200546F53716C537472696E6700537472696E6753706C69744F7074696F6E7300456E636F64696E67006765745F44656661756C74004765744279746573005F5F5374617469634172726179496E69745479706553697A653D3130340024246D6574686F643078363030303031622D310052756E74696D6548656C706572730041727261790052756E74696D654669656C6448616E646C6500496E697469616C697A654172726179004279746500476574537472696E67000000000330000003F696010100053000300000074651BF4E074E0103465101054651BF4E0105BF4E074E0103BF4E01095A00450052004F0000132000480055004E0044005200450044002000000320000017200041004E0044002000430045004E00540053002000000D430045004E005400530020000015F696F958308DC15386800D4F4696D2674C63967301250652D2890657FE62704FDF4E074EFE62704FDF4EBF4EFE62704FDF4E4651FE62704FDF4E01074F004E0045000007540057004F00000B54004800520045004500000946004F0055005200000946004900560045000007530049005800000B53004500560045004E00000B4500490047004800540000094E0049004E0045000007540045004E00000D45004C004500560045004E00000D5400570045004C0056004500001154004800490052005400450045004E00001146004F00550052005400450045004E00000F4600490046005400450045004E00000F5300490058005400450045004E00001353004500560045004E005400450045004E00001145004900470048005400450045004E0000114E0049004E0045005400450045004E00000D5400570045004E0054005900000D540048004900520054005900000B46004F00520054005900000B46004900460054005900000B53004900580054005900000F53004500560045004E0054005900000D450049004700480054005900000D4E0049004E004500540059000011540048004F005500530041004E004400000F4D0049004C004C0049004F004E00000F420049004C004C0049004F004E0000115400520049004C004C0049004F004E0000032B0000032D0001032A0000032F000003250000053C003C0000053E003E000003260000035E0000037C0000032C0000033F0000007139046D49C022408A849F2B3F01E04D0008B77A5C561934E08902060E03061D0E0400010E0E02060802060203200001072002011111111505200101110C04200011110306121907200201121D1115052001011110042000121D05200101122105200101122506000111151129060001121D121D060001122D1111070002011C101115090003121D121D111103080002122D121D121D042001010E05200101115D0420010108040001020E0320000E050002020E0E05000111710E070002117111710807000202117111710620011D0E1D030500020E0E0E0520020E08080320000804200103080500020E1C1C0600030E1C1C1C0520020E0E0E0520010E1D0312070C1D0E0E0E0E080808080E1D031D031D03040001080E0500010E1D0E0700040E0E0E0E0E0600030E0E0E0E1707111D0E0E0E0E0E0E0E0808080808080E1D031D0E1D0E030000010807031D0E1D0E1D0E0620010111808908010001000000000006200101118091032000020401000000080615128099020E080715128099020E08072002011300130108200202130010130105000111110809000211809D111111110600010211809D0407020E086101000200000004005402174973496E76617269616E74546F4475706C696361746573005402124973496E76617269616E74546F4E756C6C73015402124973496E76617269616E74546F4F726465720054080B4D61784279746553697A65FFFFFFFF0420001D0306200112191D0305200112190E05200112191C05000111150E0520010111150307010E03061115052001011D0308B03F5F7F11D50A3A0800030E0E1180A908170100010054020F497344657465726D696E6973746963014901000200540E1146696C6C526F774D6574686F644E616D650B4475616C46696C6C526F77540E0F5461626C65446566696E6974696F6E126974656D206E76617263686172286D61782906000111809D020B000211809D11809D11809D070704081D0E08080520020E08034A01000200540E1146696C6C526F774D6574686F644E616D650C53706C697446696C6C526F77540E0F5461626C65446566696E6974696F6E126974656D206E76617263686172286D61782904200011150920021D0E1D031180AD0920021D0E1D0E1180AD14070A1D0E0E0E1D0E1D0E1D0E1115111511151D03060703081219080500001280B10520011D050E03061120090002011280B91180BD0520010E1D050D07081D050808081D0808081D050F01000A5341462E53716C436C7200000501000000002F01002AE88B8FE5B79EE8819AE8BEBEE4BFA1E681AFE69C8DE58AA1E592A8E8AFA2E69C89E99990E585ACE58FB8000047010042436F707972696768742028632920323031332D3230313520E88B8FE5B79EE8819AE8BEBEE4BFA1E681AFE69C8DE58AA1E592A8E8AFA2E69C89E99990E585ACE58FB800000C010007312E302E302E3000000801000200000000000801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F77730100000000000048AF5500000000020000001C010000484700004829000052534453B534699BD0F483499C63855A1F9A34A001000000643A5C4D79576F726B7370616365735C4A6F64656E536F66745C7472756E6B5C30322E436F64655C5341465C5341462E53716C436C725C6F626A5C52656C656173655C5341462E53716C436C722E70646200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000008C4800000000000000000000AE480000002000000000000000000000000000000000000000000000A04800000000000000000000000000000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C0000000000FF250020001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001001000000018000080000000000000000000000000000001000100000030000080000000000000000000000000000001000000000048000000586000005C03000000000000000000005C0334000000560053005F00560045005200530049004F004E005F0049004E0046004F0000000000BD04EFFE00000100000001000000000000000100000000003F000000000000000400000002000000000000000000000000000000440000000100560061007200460069006C00650049006E0066006F00000000002400040000005400720061006E0073006C006100740069006F006E00000000000000B004BC020000010053007400720069006E006700460069006C00650049006E0066006F00000098020000010030003000300030003000340062003000000030000B00010043006F006D006D0065006E007400730000005300410046002E00530071006C0043006C0072000000000040000F00010043006F006D00700061006E0079004E0061006D00650000000000CF82DE5D5A80BE8FE14F6F600D67A152A854E28B096750966C51F8530000000040000B000100460069006C0065004400650073006300720069007000740069006F006E00000000005300410046002E00530071006C0043006C00720000000000300008000100460069006C006500560065007200730069006F006E000000000031002E0030002E0030002E003000000040000F00010049006E007400650072006E0061006C004E0061006D00650000005300410046002E00530071006C0043006C0072002E0064006C006C00000000007400270001004C006500670061006C0043006F007000790072006900670068007400000043006F0070007900720069006700680074002000280063002900200032003000310033002D0032003000310035002000CF82DE5D5A80BE8FE14F6F600D67A152A854E28B096750966C51F8530000000048000F0001004F0072006900670069006E0061006C00460069006C0065006E0061006D00650000005300410046002E00530071006C0043006C0072002E0064006C006C000000000038000B000100500072006F0064007500630074004E0061006D006500000000005300410046002E00530071006C0043006C00720000000000340008000100500072006F006400750063007400560065007200730069006F006E00000031002E0030002E0030002E003000000038000800010041007300730065006D0062006C0079002000560065007200730069006F006E00000031002E0030002E0030002E003000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004000000C000000C03800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000;
GO
PRINT N'正在创建 [dbo].[CalcValue]...';
GO

CREATE AGGREGATE [dbo].[CalcValue](@value INT, @operate NVARCHAR (MAX))
    RETURNS INT
    EXTERNAL NAME [SAF.SqlClr].[CalcValue];
GO

PRINT N'正在创建 [dbo].[ConcatString]...';
GO
CREATE AGGREGATE [dbo].[ConcatString](@value NVARCHAR (MAX), @connector NVARCHAR (MAX))
    RETURNS NVARCHAR (MAX)
    EXTERNAL NAME [SAF.SqlClr].[ConcatString];
GO

PRINT N'正在创建 [dbo].[PadLeft]...';
GO
CREATE FUNCTION [dbo].[PadLeft]
(@input NVARCHAR (MAX), @totalWidth INT, @paddingChar NCHAR (1))
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[PadLeft]
GO

PRINT N'正在创建 [dbo].[PadRight]...';
GO
CREATE FUNCTION [dbo].[PadRight]
(@input NVARCHAR (MAX), @totalWidth INT, @paddingChar NCHAR (1))
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[PadRight]
GO

PRINT N'正在创建 [dbo].[ConvertMoneyToCN]...';
GO
CREATE FUNCTION [dbo].[ConvertMoneyToCN]
(@money MONEY)
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[ConvertMoneyToCN]
GO

PRINT N'正在创建 [dbo].[ConvertMoneyToEN]...';
GO
CREATE FUNCTION [dbo].[ConvertMoneyToEN]
(@money MONEY)
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[ConvertMoneyToEN]
GO

PRINT N'正在创建 [dbo].[ConvertToProperCase]...';
GO
CREATE FUNCTION [dbo].[ConvertToProperCase]
(@input NVARCHAR (MAX))
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[ConvertToProperCase]
GO

PRINT N'正在创建 [dbo].[ConvertToSimplifiedChinese]...';
GO
CREATE FUNCTION [dbo].[ConvertToSimplifiedChinese]
(@input NVARCHAR (MAX))
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[ConvertToSimplifiedChinese]
GO

PRINT N'正在创建 [dbo].[ConvertToTraditionalChinese]...';
GO
CREATE FUNCTION [dbo].[ConvertToTraditionalChinese]
(@input NVARCHAR (MAX))
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[ConvertToTraditionalChinese]
GO

PRINT N'正在创建 [dbo].[ConvertToPinyin]...';
GO
CREATE FUNCTION [dbo].[ConvertToPinyin]
(@input NVARCHAR (MAX))
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[ConvertToPinyin]
GO

PRINT N'正在创建 [dbo].[SplitString]...';
GO
CREATE FUNCTION [dbo].[SplitString]
(@input NVARCHAR (MAX), @splitter NVARCHAR (MAX))
RETURNS 
     TABLE (
        [item] NVARCHAR (MAX) NULL)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[SplitString]
GO

PRINT N'正在创建 [dbo].[Dual]...';
GO
CREATE FUNCTION [dbo].[Dual]
(@count INT)
RETURNS 
     TABLE (
        [item] NVARCHAR (MAX) NULL)
AS
 EXTERNAL NAME [SAF.SqlClr].[UserDefinedFunctions].[Dual]
GO

--重新生成列绑定
PRINT N'正在将表 [dbo].[sysMenu] 表中Pinyin列绑定到ConvertToPinyin...';
GO
ALTER TABLE [dbo].[sysMenu]
    ADD [Pinyin] AS ([dbo].[ConvertToPinyin]([Name]));

PRINT N'操作完成。';
GO
