create or replace procedure ADDALUNOS (NewALU_Id in tbalunos.alu_id%TYPE,NewALU_NM in tbalunos.alu_nm%TYPE,NewALU_TEL_NUM in tbalunos.alu_nr_tel%TYPE, NewALU_DT_NASCIMENTO in tbalunos.alu_dt_nascimento%TYPE) 
is
Begin
    Insert into TBALUNOS (ALU_ID,ALU_NM, ALU_NR_TEL, ALU_DT_NASCIMENTO)
VALUES (NewALU_Id, NewALU_NM, NewALU_TEL_NUM, NewALU_DT_NASCIMENTO);
End;



