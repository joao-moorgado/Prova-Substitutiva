import { useEffect, useState } from "react";
import { IMC } from "../../../models/IMC";
import { useNavigate } from "react-router-dom";
import { Aluno } from "../../../models/Aluno";

function IMCCadastrar() {
    const navigate = useNavigate();
    const [altura, setAltura] = useState("");
    const [peso, setPeso] = useState("");
    const [alunoId, setAlunoId] = useState("");
    const [alunos, setAlunos] = useState<Aluno[]>([]);

    useEffect(() => {
        carregarAlunos();
      }, []);

    function carregarAlunos() {
        fetch("http://localhost:5184/api/alunos/listar")
          .then((resposta) => resposta.json())
          .then((alunos: Aluno[]) => {
            setAlunos(alunos);
        });
    }
        
    function cadastrarIMC(e: any) {
        const imc: IMC = {
            altura: parseFloat(altura),
            peso: parseFloat(peso),
            alunoId: alunoId,
    }

    fetch("http://localhost:5184/api/imcs/cadastrar/listar", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(imc),
    })
        .then((resposta) => resposta.json())
        .then((imc: IMC) => {
            navigate("/pages/imc/listar");
        });
        e.preventDefault();
    }
    return (
        <div>
            <h1>Cadastrar IMC</h1>
            <form onSubmit={cadastrarIMC}>
                <label>Altura:</label>
                <input 
                    type="text"
                    placeholder="Digite a altura do aluno"
                    onChange= {(e) => setAltura(e.target.value)}
                    required
                 />
                 <br />
                 <label>Peso</label>
                    <input
                        type="text"
                        placeholder="Digite o peso do aluno"
                        onChange= {(e) => setPeso(e.target.value)}
                        required
                    />
                    <br />
                    <label>Aluno</label>
                    <select onChange={(e) => setAlunoId(e.target.value)}>
                        <option>Selecione um aluno</option>
                        {alunos.map((aluno) => {
                            return <option key={aluno.id} value={aluno.id}>{aluno.nome} {aluno.sobrenome}</option>
                        })}
                    </select>
                    <br />
                    <button type="submit">Cadastrar</button>
            </form>

        </div>
    )
}


export default IMCCadastrar;