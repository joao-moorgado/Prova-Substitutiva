import React from "react";
import AlunoCadastrar from "./components/pages/aluno/aluno-cadastrar";
import IMCCadastrar from "./components/pages/imc/imc-cadastrar";
import { BrowserRouter, Link, Routes, Route } from "react-router-dom";

function App() {
  return (
    <div>
      <BrowserRouter>
        <nav>
          <Link to="/pages/aluno/cadastrar">Cadastrar Aluno</Link>
        </nav>
        <nav>
          <Link to="/pages/imc/cadastrar">Cadastrar IMC</Link>
        </nav>
        <Routes>
          <Route path="/pages/aluno/cadastrar" element={<AlunoCadastrar />} />
          <Route path="pages/imc/cadastrar" element={<IMCCadastrar />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}
//4 - OBRIGATORIAMENTE o componente DEVE ser exportado
export default App;