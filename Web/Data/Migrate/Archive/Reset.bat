


@echo off
cls

sqlcmd -E -S .\sqlexpress -i ../Archive/DropDb.sql   
sqlcmd -E -S .\sqlexpress -i ../Migration.sql


