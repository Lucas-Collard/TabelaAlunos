create or replace PROCEDURE prUSER_SEL( cur_user out SYS_REFCURSOR)
IS
BEGIN

  open cur_user for
  SELECT    USER_ID,
            USER_NAME, 
            USER_PASSWORD, 
            USER_FULLNAME, 
            USER_TOKEN,
            USER_TOKEN_TIME
            
  FROM TBUSER
  
  ORDER BY USER_ID;
END;