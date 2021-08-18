create or replace procedure DelAlunos (del_id in tbalunos.alu_id%TYPE ) 
is
Begin
    delete from tbalunos
WHERE alu_id = del_id;


End;


