CREATE LOGIN appuser WITH password='';
CREATE USER appuser FROM LOGIN appuser;
ALTER ROLE db_owner ADD MEMBER appuser; 
