create or replace procedure BK_EXCLUSION (ex_del_id in tbalunos.alu_id%TYPE,ex_dt_exclu in tbalunosbk.dt_exclu%type)

IS 
BEGIN 
        insert into tbalunosbk(ALU_NM,ALU_NR_TEL,ALU_DT_NASCIMENTO,ALU_ID,DT_EXCLU,ALU_DT_CAD)
        select tbalunos.ALU_NM,tbalunos.ALU_NR_TEL,tbalunos.ALU_DT_NASCIMENTO,tbalunos.ALU_ID,tbalunos.ALU_DT_CAD, ex_dt_exclu
        from tbalunos 
        where ALU_ID = ex_del_id; 

END;
