import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { show_alert } from '../functions'

export default function Docenteestudiantelista() {
  const url = 'https://localhost:5001/api/CandidatoEstudiante';
  const [candidatoEstudiante, setcandidatoEstudiante] = useState([]);
  const [candidatoEstudianteId, setCandidatoEstudianteId] = useState('');
  const [nombre, setNombre] = useState('');
  const [apellido, setApellido] = useState('');
  const [asistencia, setAsistencia] = useState('');
  const [operation, setOperations] = useState(1);
  const [title, setTitle] = useState('');

  useEffect(() => {
    getCandidatoEstudiante();
  }, []);

  console.log(candidatoEstudiante);

  const getCandidatoEstudiante = async () => {
    try {
      const response = await axios.get(url);
      setcandidatoEstudiante(response.data);
    } catch (error) {
      console.error('Error al obtener al estudiante:', error);
    }
  };

  const openModal = (op, candidatoEstudiante) => {
    setOperations(op);
    if (op === 1) {
      setTitle('Registrar asistencia');
      setCandidatoEstudianteId(candidatoEstudiante.candidatoEstudianteId); 
      setNombre(candidatoEstudiante.nombre);
      setApellido(candidatoEstudiante.apellido);
      setAsistencia('');
    } else if (op === 2) {
      setTitle('Editar asistencia');
      setCandidatoEstudianteId(candidatoEstudiante.candidatoEstudianteId);
      setNombre(candidatoEstudiante.nombre);
      setApellido(candidatoEstudiante.apellido);
      setAsistencia(candidatoEstudiante.asistencia)
    }
    window.setTimeout(function () {
      document.getElementById('Nombre').focus();
    }, 500);
  };

  const validar = () => {
    if (nombre.trim() === "") {
      show_alert("Escribe el nombre del estudiante", "Escribe el nombre del nombre");
    } else if (apellido === "") {
      show_alert("Escribe el apellido del estudiante", "Escribe el estado del apellido");
    } else {
      let parametros;
      let metodo;

      if (operation === 1) {
        parametros = { nombre: nombre, apellido: apellido };
        metodo = "POST";
        
      } else {
        parametros = { nombre: nombre, apellido: apellido };
        metodo = "PUT";
      }

      enviarSolicitud(metodo, parametros);
    }
  };

  const enviarSolicitud = async (metodo, parametros) => {
    if (metodo === "POST") {
      axios
        .post(`${url}`, parametros)
        .then(function (respuesta) {
          show_alert("Estudiante añadido exitosamente", "success");
          document.getElementById("btnCerrar").click();
          getCandidatoEstudiante();
        })
        .catch(function (error) {
          show_alert("error", "Error de solucitud");
          console.log(error);
        });
    } else if (metodo === "PUT") {
      axios
        .put(`${url}/${candidatoEstudianteId}`, parametros)
        .then(function (respuesta) {
          console.log("Solicitud PUT exitosa:", respuesta.data);
          var tipo = respuesta.data[0];
          var msj = respuesta.data[1];
          show_alert("Cargo editado con éxito", "success");
          document.getElementById("btnCerrar").click();
          getCandidatoEstudiante();
        })
        .catch(function (error) {
          show_alert("Error de solucitud", "error");
          console.log(error);
        });
    }
  };

  return (
    <React.Fragment>
        <main className="full-box main-container">
          <section className="full-box nav-lateral">
            <div className="full-box nav-lateral-bg show-nav-lateral"></div>
            <div className="full-box nav-lateral-content">
              <figure className="full-box nav-lateral-avatar">
                <i className="far fa-times-circle show-nav-lateral"></i>
                <img src="/assets/avatar/Avatar_negro.jpg" className="img-fluid" alt="Avatar" />
                <figcaption className="roboto-medium text-center">
                  Juan David Novoa Yanguma <br />
                  <small className="roboto-condensed-light">
                    <p>
                      <span className="badge badge-success">Docente</span>
                    </p>
                  </small>
                </figcaption>
              </figure>
              <div className="full-box nav-lateral-bar"></div>
              <nav className="full-box nav-lateral-menu">
                <ul>
                  <li>
                    <Link to={'/Docente'}>
                      <i className="fab fa-dashcube fa-fw"></i> &nbsp; Inicio
                    </Link>
                  </li>
                  <li>
                    <a href="#" className="nav-btn-submenu">
                      <i className="fas fa-layer-group fa-fw"></i> &nbsp; Cursos <i className="fas fa-chevron-down"></i>
                    </a>
                    <ul>
                      <li>
                        <Link to={'/Docenteelegircurso'}>
                          
                            <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Elegir Cursos
                          
                        </Link>
                      </li>
                    </ul>
                   </li>
                  <li>
                    <a href="#" className="nav-btn-submenu">
                      <i className="fas fa-users fa-fw"></i> &nbsp; Estudiantes <i className="fas fa-chevron-down"></i>
                    </a>
                    <ul>
                      <li>
                        <Link to={'/Docenteestudiantelista'}>
                          <a>
                            <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Estudiante
                          </a>
                        </Link>
                      </li>
                      <li>
                        <Link to={'/Docentebuscarestudiante'}>
                          <a>
                            <i className="fas fa-search fa-fw"></i> &nbsp; Buscar Estudiante
                          </a>
                        </Link>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <Link to={'/DocenteReclamos'}>
                      <i className="fas fa-exclamation-circle fa-fw"></i> &nbsp; Reclamos
                    </Link>
                  </li>
                </ul>
              </nav>
            </div>
          </section>

          <section className="full-box page-content">
            <nav className="full-box navbar-info">
              <a className="float-left show-nav-lateral">
                <i className="fas fa-exchange-alt"></i>
              </a>
              <Link to={'/Docenteuserupdate'}>
                <a>
                  <i className="fas fa-user-cog"></i>
                </a>
              </Link>
              <a className="btn-exit-system">
                <i className="fas fa-power-off"></i>
              </a>
            </nav>

            <div className="full-box page-header">
              <h3 className="text-left">
                <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE ESTUDIANTES
              </h3>
              <p className="text-justify"></p>
            </div>

            <div className="container-fluid">
  <div className="table-responsive">
    <table className="table table-dark table-sm">
      <thead>
        <tr className="text-center roboto-medium">
          <th>#</th>
          <th>ID</th>
          <th>NOMBRE</th>
          <th>APELLIDO</th>
          <th>ASISTENCIA</th>
          <th>NOTA</th>
        </tr>
      </thead>
      <tbody>
        {candidatoEstudiante.length > 0 &&
          candidatoEstudiante.map((CandidatoEstudiante, i) => (
            <tr key={CandidatoEstudiante.candidatoEstudianteId} className="text-center">
              <td className="#">{i + 1}</td>
              <td className="ID">{CandidatoEstudiante.candidatoEstudianteId}</td>
              <td className="nombre">{CandidatoEstudiante.nombre}</td>
              <td className="apellido">{CandidatoEstudiante.apellido}</td>
              <td className="asistencia">
                <div className="col-12 col-md-6">
                  <div className="form-group">
                      <button
                onClick={() => openModal(1)}
                className="btn btn-secundary"
                data-bs-toggle="modal"
                data-bs-target="#modalCandidatoEstudiante"
                type="button"
                
              >
                <i className="bi bi-clipboard2-check text-center"></i> Añadir asistencia
              </button>
                  </div>
                </div>
              </td>
              <td className="nota">
                <div className="col-12 col-md-6">
                  <div className="form-group">
                    <input
                      type="text"
                      pattern="[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{1,40}"
                      className="form-control"
                      name="cliente_nombre"
                      id="cliente_nombre"
                      maxLength="40"
                    />
                  </div>
                </div>
              </td>
            </tr>
          ))}
      </tbody>
    </table>
  </div>
</div> {/* Correctly placed closing div tag */}
</section>

</main>


<div id="modalCandidatoEstudiante" className="modal fade" aria-hidden="true">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <label className="h5">{title}</label>
              <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div className="modal-body">
              <input type="hidden" id="candidatoEstudianteId" />
              <div className="input-group mb-3">
                
                
              </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fa-solid fa-comment"></i></span>
                    <input
                        type="text"
                        id="Nombre"
                        className="form-control"
                        placeholder="NOMBRE"
                        value={nombre}
                        onChange={(e) => setNombre(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                      <span className="input-group-text"><i className="fa-solid fa-comment"></i></span>
                      <input
                        type="text"
                        id="Apellido"
                        className="form-control"
                        placeholder="APELLIDO"
                        value={apellido}
                        onChange={(e) => setApellido(e.target.value)}
                      />
                    </div>
                    <div className='d-grid col-6 mx-auto'>
                    <div className="d-flex justify-content-center align-items-center h-100">
                      <button onClick={() => validar()} className='btn btn-success'>Guardar</button>
                    </div>
                    </div>
                  </div>
                  <div className='modal-footer'>
                  <div className="d-flex justify-content-center align-items-center h-100">
                    <button type='button' id="btnCerrar" className='btn btn-secondary' data-bs-dismiss='modal'>Cerrar</button>
                  </div>
                  </div>
                </div>
              </div>
            </div>
          
    </React.Fragment>
  );
}