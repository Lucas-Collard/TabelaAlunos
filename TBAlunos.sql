create or replace procedure Exclusao(cur_ex out SYS_REFCURSOR)

IS
BEGIN
    open cur_ex for
    SELECT ALU_ID,ALU_NM, ALU_NR_TEL, ALU_DT_NASCIMENTO, alu_dt_cad,DT_EXCLU
    FROM TBALUNOSBK ORDER BY alu_id;


END;