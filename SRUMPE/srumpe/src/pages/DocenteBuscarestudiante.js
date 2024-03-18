import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';

export default function Docentebuscarestudiante() {

    const url = 'https://localhost:5001/api/CandidatoEstudiante';
  const [candidatoEstudiante, setcandidatoEstudiante] = useState([]);
  const [candidatoEstudianteId, setCandidatoEstudianteId] = useState('');
  const [nombres, setNombres] = useState('');
  const [apellidos, setApellidos] = useState('');
  const [tipodepersona, settipodepersona] = useState('');
  const [fechaNacimiento, setFechaNacimiento] = useState('');
  const [operation, setOperation] = useState(1);
  const [title, setTitle] = useState('');
  const [searchTerm, setSearchTerm] = useState('');

  
  useEffect(() => {
    getCandidatoEstudiante();
  }, []);

  const getCandidatoEstudiante = async () => {
    try {
      const response = await axios.get(url);
      setcandidatoEstudiante(response.data);
    } catch (error) {
      console.error('Error al obtener al estudiante:', error);
    }
  };

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
  };

  const filteredestudiante = candidatoEstudiante.filter((estudiante) => {
    const fullName = `${estudiante.nombre} ${estudiante.apellido}`.toLowerCase();
    return fullName.includes(searchTerm.toLowerCase());
  });

  const openModal = (op, estudiante) => {
    setOperation(op);
    if (op === 1) {
      setTitle('Registrar Acudiente');
      setCandidatoEstudianteId('');
      setNombres('');
      setApellidos('');
      setFechaNacimiento('');
      settipodepersona('');
    } else if (op === 2) {
      setTitle('Editar Acudiente');
      setCandidatoEstudianteId(estudiante.candidatoEstudianteId);
      setNombres(estudiante.nombres);
      setApellidos(estudiante.apellidos);
      setFechaNacimiento(estudiante.fechaNacimiento);
      settipodepersona(estudiante.tipodepersona);
    }
  };

  const validar = () => {
    if (nombres.trim() === '') {
      show_alert('Escribe el nombre del estudiante', 'Escribe el nombre del estudiante');
    } else if (apellidos.trim() === '') {
      show_alert('Escribe el apellido del estudiante', 'Escribe el apellido del estudiante');
    } else if (fechaNacimiento.trim() === '') {
      show_alert('Escribe la fecha de nacimiento del estudiante', 'Escribe la fecha de nacimiento del estudiante');
    } 
     else {
      const parametros = {
        nombres,
        apellidos,
        fechaNacimiento,
      };
      const metodo = operation === 1 ? 'POST' : 'PUT';
      enviarSolicitud(metodo, parametros);
    }
  };

  const enviarSolicitud = async (metodo, parametros) => {
    try {
      const response = await (metodo === 'POST'
        ? axios.post(url, parametros)
        : axios.put(`${url}/${candidatoEstudianteId}`, parametros));
  
      if (response.data) {
        show_alert('Operación exitosa', 'success');
        document.getElementById('btnCerrar').click();
        getCandidatoEstudiante();
      } else {
        show_alert('Error en la solicitud', 'error');
      }
    } catch (error) {
      show_alert('Error en la solicitud', 'error');
      console.error(error);
    }
  };
  const deleteCandidatoestudiante = (candidatoEstudianteId, nombres) => {
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: `¿Seguro quieres eliminar al acudiente ${nombres}?`,
      icon: 'question',
      text: 'No se podrá dar marcha atrás',
      showCancelButton: true,
      confirmButtonText: 'Si, eliminar',
      cancelButtonText: 'Cancelar',
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          await axios.delete(`${url}/${candidatoEstudianteId}`);
          show_alert('Acudiente eliminado exitosamente', 'success');
          getCandidatoEstudiante();
        } catch (error) {
          show_alert('Error al eliminar al acudiente', 'error');
          console.error(error);
        }
      } else {
        show_alert('El acudiente no fue eliminado', 'info');
      }
    });
  };

    return(
        
            <React.Fragment>
<main className="full-box main-container">	
	
	<section className="full-box nav-lateral">
		<div className="full-box nav-lateral-bg show-nav-lateral"></div>
		<div className="full-box nav-lateral-content">
			<figure className="full-box nav-lateral-avatar">
				<i className="far fa-times-circle show-nav-lateral"></i>
				<figcaption className="SRMNPE text-center">
					SRUNPE <br/><small className="roboto-condensed-light"></small>
				</figcaption>
				<img src="/assets/avatar/Avatar_negro.jpg" className="img-fluid" alt="Avatar"/>
				<figcaption className="roboto-medium text-center">
					Juan David Novoa Yanguma <br/><small className="roboto-condensed-light"><p><span className="badge badge-success">Docente</span></p></small>
				</figcaption>
			</figure>
			<div className="full-box nav-lateral-bar"></div>
			<nav className="full-box nav-lateral-menu">
            <ul>
                                    <li>
                                    <Link to={'/docente'}>
                                        <i className="fab fa-dashcube fa-fw"></i> &nbsp; Inicio
                                    </Link>
                                    </li>
                                    <li>
                                        <a href="#" className="nav-btn-submenu"><i className="fas fa-layer-group fa-fw"></i> &nbsp; Cursos <i className="fas fa-chevron-down"></i></a>
                                        <ul>	
                                        
                                            <li>
                                                <Link to={'/Docenteelegircurso'}>
                                                <a ><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Elegir Cursos</a>
                                                </Link>	
                                            </li>
                                        							
                                        </ul>
                                    </li>
                                    <li>
                                        <a href="#" className="nav-btn-submenu"><i className="fas fa-users fa-fw"></i> &nbsp;  Estudiantes <i className="fas fa-chevron-down"></i></a>
                                        <ul>  
                                        
                                        <li>
                                            <Link to={'/Docenteestudiantelista'}>
                                            <a ><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Estudiante</a>
                                            </Link>
                                        </li>
                                        
                                        
                                        <li>
                                            <Link to={'/Docentebuscarestudiante'}>
                                            <a ><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Estudiante</a>
                                            </Link>
                                        </li>
                                        
                                        </ul>
                                    </li>
                                    {/*<li>
                                    <Link to={'/DocenteReclamos'}>
                                        <i className="fas fa-exclamation-circle fa-fw"></i> &nbsp; Reclamos
    </Link>
    </li>*/}
                                </ul>
				</nav>
			</div>
		</section>
	


		
		<section className="full-box page-content">
        <nav className="full-box navbar-info">
            <a className="float-left show-nav-lateral">
                <i className="fas fa-exchange-alt"></i>
            </a>
            <Link to={'/DocenteuserUpdate'}>
            <a >
                <i className="fas fa-user-cog"></i>
            </a>
            </Link>
            <a className="btn-exit-system">
                <i className="fas fa-power-off"></i>
            </a>
        </nav>

			
			<div className="full-box page-header">
				<h3 className="text-left">
					<i className="fas fa-search fa-fw"></i> &nbsp; BUSCAR ESTUDIANTE
				</h3>
				<p className="text-justify">
					
				</p>
			</div>

			<div className="container-fluid">
                <ul className="full-box list-unstyled page-nav-tabs">
                    <li>
                    <Link to={'/Docenteestudiantelista'}>
                        <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; lista de estudiantes
                    </Link>
                    </li>
                    <li>
                        <a className="active" href="Docente-buscar-estudiante.html"><i className="fas fa-search fa-fw"></i> &nbsp;buscar estudiante</a>
                    </li>
                    
                </ul>
            </div>
			
			
			<div className="container-fluid">
				<form className="form-neon" onSubmit={(e) => e.preventDefault()}>
					<div className="container-fluid">
						<div className="row justify-content-md-center">
							<div className="col-12 col-md-6">
								<div className="form-group">
									<label for="inputSearch" className="frome bmd-label-floating">¿Qué estudiante estas buscando?</label>
									<input type="text" className="form-control" name="busqueda-" id="inputSearch" maxlength="30" value={searchTerm} onChange={handleSearchChange}/>
								</div>
							</div>
							<div className="col-12">
								<p className="text-center" >
									<button type="submit" className="btn btn-raised btn-info" onClick={getCandidatoEstudiante}><i className="fas fa-search"></i> &nbsp; BUSCAR</button>
								</p>
							</div>
						</div>
					</div>
				</form>
			</div>

			
			<div className="container-fluid">
				
			


			<div className="table-responsive">
                <table className="table table-dark table-sm">
                <thead>
                <tr className="text-center roboto-medium">
                  <th>#</th>
                  
                  <th>NOMBRE</th>
                  <th>APELLIDO</th>
                  <th>ASISTENCIA</th>
                  <th>NOTA</th>
                  
                </tr>
              </thead>
              <tbody>
              {filteredestudiante.map((CandidatoEstudiante, i) => (
                <tr key={CandidatoEstudiante.candidatoEstudianteId} className="text-center">
                  <td className="#">{i + 1}</td>
                  
                  <td className="nombre" >{CandidatoEstudiante.nombre}</td>
                  <td className="apellido">{CandidatoEstudiante.apellido}</td>
                  <td className="asistencia">
                    <div className="col-12 col-md-6">
                      <div className="form-group">
                        <select className="form-control" name="item_estado" id="item_estado">
                          <option value="" selected="" disabled="">
                            Seleccione una opción
                          </option>
                          <option selected="" value="Habilitado">
                            ASISTENCIA
                          </option>
                          <option value="Deshabilitado">INASISTENCIA</option>
                          <option value="Deshabilitado">EVADIENDO CLASE</option>
                        </select>
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
              </div>
              <div className="container-fluid">
              <nav aria-label="Page navigation example">
                <ul className="pagination justify-content-center">
                  <li className="page-item disabled">
                    <a className="page-link" href="#" tabIndex="-1">
                      Anterior
                    </a>
                  </li>
                  <li className="page-item">
                    <a className="page-link" href="#">
                      1
                    </a>
                  </li>
                  <li className="page-item">
                    <a className="page-link" href="#">
                      2
                    </a>
                  </li>
                  <li className="page-item">
                    <a className="page-link" href="#">
                      3
                    </a>
                  </li>
                  <li className="page-item">
                    <a className="page-link" href="#">
                      Siguiente
                    </a>
                  </li>
                </ul>
              </nav>
            </div>
            </section>
	
        </main>
	

            </React.Fragment>
        
    )
}