--1.�鿴����״̬
EXEC sp_configure 'clr enabled'
--2.����clr(1Ϊ���ã�0Ϊ�ر�)
EXEC sp_configure 'clr enabled',1
--ִ��������������ʾ:������RECONFIGURE�����а�װ
RECONFIGURE WITH OVERRIDE