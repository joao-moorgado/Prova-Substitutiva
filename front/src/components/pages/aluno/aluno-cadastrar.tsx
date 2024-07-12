import { useEffect, useState } from "react";
import { Aluno } from "../../../models/Aluno";
import { useNavigate } from "react-router-dom";

function AlunoCadastrar() {
    const navigate = useNavigate();
    const [nome, setNome] = useState("");
    const [sobrenome, setSobrenome] = useState("");

    function CadastrarAluno(e: any) {
        const aluno: Aluno = {
            nome: nome,
            sobrenome: sobrenome,
        };

        fetch("http://localhost:5184/api/alunos/cadastrar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(aluno),
    })
            .then((resposta) => resposta.json())
            .then((aluno: Aluno) => {
                navigate("/pages/aluno/listar");
            });
        e.preventDefault();
    }
    return (
        <div>
            <h1>Cadastrar Aluno</h1>
            <form onSubmit={CadastrarAluno}>
                <label>Nome:</label>
                <input 
                    type="text"
                    placeholder="Digite o nome do aluno"
                    onChange= {(e) => setNome(e.target.value)}
                    required
                 />
                 <br />
                 <label>Sobrenome</label>
                    <input
                        type="text"
                        placeholder="Digite o sobrenome do aluno"
                        onChange= {(e) => setSobrenome(e.target.value)}
                        required
                    />
                    <br />
                    <button type="submit">Cadastrar</button>
            </form>
        </div>
    )
}

export default AlunoCadastrar;