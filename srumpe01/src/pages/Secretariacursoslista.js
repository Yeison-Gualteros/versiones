import  React, { useEffect, useState } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';

export default function Secretariacursoslista() {
    const url = 'https://localhost:7284/api/cursos';
    const [cursos, setCursos] = useState([]);
    const [cursoId, setcursoId] = useState('');
    const [codigo, setCodigo] = useState('');
    const [description, setdescripcion] = useState('');
    const [departamentoacademico, setdepartamentoacademico] = useState('');
    const [profesorasignado, setprofesorasignado] = useState('');
    const [cursoSeleccionado, setCursoSeleccionado] = useState('');
    const [aulasAsignadas, setaulasAsignadas] = useState('');
    const [fechalimiteincripcion, setfechalimiteincripcion] = useState('');
    const [metodosenseñanza, setmetodosenseñanza] = useState('');
    const [operation, setOperation] = useState(1);
    const [title, setTitle] = useState('');

    const url2 = 'https://localhost:7284/api/Docente'
    const [Docente, setDocente] = useState([]);
    const [DocenteId, setDocenteId] = useState('');
    const [nombre, setNombre] = useState('');
    const [apellido, setapellido] = useState('');


    useEffect(() => {
        getCursos();
    }, []);

    useEffect(() => {
      fetch(url2)
      .then(response => response.json())
      .then((data) => setDocente(data))
      .catch((error) => console.error('Error fetching cursos:', error))
  }, [url2]);

    const getCursos = async () => {
        const respuesta = await axios.get(url);
        setCursos(respuesta.data);
    };

    const openModal = (op, curso) => {
        setOperation(op);
        if (op === 1) {
            setTitle('Registrar curso');
            setcursoId('');
            setCodigo('');
            setCursoSeleccionado('');
            setdescripcion('');
            setdepartamentoacademico('');
            setprofesorasignado('');
            setaulasAsignadas('');
            setfechalimiteincripcion('');
            setmetodosenseñanza('');
            setDocenteId('');
            setNombre('');
            setapellido('');
            setDocente([]);

        } if (op === 2) {
            setTitle('Editar curso');
            setcursoId(curso.cursosId);
            setCodigo(curso.codigo);
            setCursoSeleccionado(curso.cursoSeleccionado);
            setdescripcion(curso.descripcion);
            setdepartamentoacademico(curso.departamentoacademico);
            setprofesorasignado(curso.profesorasignado);
            setaulasAsignadas(curso.aulasAsignadas);
            setfechalimiteincripcion(curso.fechalimiteincripcion);
            setmetodosenseñanza(curso.metodosenseñanza);
            setDocenteId(curso.DocenteId);
            setNombre(curso.nombre);
            setapellido(curso.apellido);
            setDocente(curso.Docente);
            console.log(curso.Docente);
        }
        window.setTimeout(function () {
            document.getElementById('Curso').focus();
        }, 500);
    };

  const validar = (function() {
    if (cursos.cursoSeleccionado.trim() === "") {
      show_alert("Escribe el nuevo curso", "Escribe el nuevo curso");
    } else if (cursos.profesorasignado.trim() === "") {
      show_alert("Seleccione el docente", "Seleccione el docente");
    }
    else if (cursos.codigo.trim() === "") {
      show_alert("Escribe el código del curso", "Escribe el código del curso");

    }
    else if (cursos.description.trim() === "") {
      show_alert("Escribe la descripción del curso", "Escribe la descripción del curso");
    }
    else if (cursos.departamentoacademico.trim() === "") {
      show_alert("Escribe el departamento academico del curso", "Escribe el departamento academico del curso");
    }
    else {
      let parametros;
      let metodo;
      if (operation === 1) {

        parametros = { 
          cursoSeleccionado: cursoSeleccionado, 
          profesorasignado: profesorasignado, 
          codigo: codigo, 
          descriccion: cursoSeleccionado.description, 
          departamentoacademico: departamentoacademico,
          aulasAsignadas: aulasAsignadas,
          fechalimiteincripcion: fechalimiteincripcion,
          metodosenseñanza: metodosenseñanza
        };
        metodo = "POST";

    }
    else {
      parametros = { cursoSeleccionado: cursoSeleccionado, 
        profesorasignado: profesorasignado, 
        codigo: codigo, 
        descriccion: cursoSeleccionado, 
        departamentoacademico: departamentoacademico,
        aulasAsignadas: aulasAsignadas,
        fechalimiteincripcion: fechalimiteincripcion,
        metodosenseñanza: metodosenseñanza

      };
      metodo = "PUT";
    }

      enviarSolicitud(metodo, parametros);
  }
  })  
    
    

  const enviarSolicitud = async (metodo, parametros) => {
    if (metodo === "POST") {
      const respuesta = await axios.post(url, parametros);
      setCursos(respuesta.data);
      show_alert('Curso Registrado', 'El curso ha sido registrado correctamente');
    }
    if (metodo === "PUT") {
      const respuesta = await axios.put(url + '/' + cursoId, parametros);
      setCursos(respuesta.data);
      show_alert('Curso Editado', 'El curso ha sido editado correctamente');
      
    }
};

  const deletecurso = (cursoId, cursoSeleccionado) => {
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: "¿Seguro quieres eliminar el curso " + cursoSeleccionado + "?",
      icon: "question",
      text: "No se podra dar marcha atras",
      showCancelButton: true,
      confirmButtonText: "Si, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          await axios.delete(`${url}/${cursoId}`);
          show_alert("Curso eliminado exitosamente", "success");
          getCursos();
        } catch (error) {
          show_alert("Error al eliminar el curso", "error");
          console.error(error);
        }
      } else {
        show_alert("El curso no fue eliminado", "info");
      }
    });
  };
    return (
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
                    Axl Julian Acuña Rubiano <br/><small className="roboto-condensed-light"><p><span className="badge badge-info">Administrativo</span></p></small>
					</figcaption>
				</figure>
				<div className="full-box nav-lateral-bar"></div>
				<nav className="full-box nav-lateral-menu">
					<ul>
						<li>
							<a href="/Secretaria"><i className="fab fa-dashcube fa-fw"></i> &nbsp; Inicio</a>
						</li>

						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-users fa-fw"></i> &nbsp;  Estudiantes <i className="fas fa-chevron-down"></i></a>
							<ul>
								
								<li>
									<a href="/Secretariaestudiantelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Estudiante</a>
								</li>
								<li>
									<a href="/Secretariabuscarestudiante"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Estudiante</a>
								</li>
							</ul>
						</li>

						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-chalkboard-user fa-fw"></i> &nbsp; Docentes <i className="fas fa-chevron-down"></i></a>
							<ul>
								{/*<li>
									<a href="nuevo-profesor.html"><i className="fas fa-plus fa-fw"></i> &nbsp; Agregar Docentes</a>
	</li>*/}
								<li>
									<a href="/Secretariadocentelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Docentes</a>
								</li>
								<li>
									<a href="/Secretariadocentebuscar"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Docentes</a>
								</li>
							</ul>
						</li>

						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-layer-group fa-fw"></i> &nbsp; Cursos <i className="fas fa-chevron-down"></i></a>
							<ul>
								{/*<li>
									<a href="curso-nuevo.html"><i className="fas fa-plus fa-fw"></i> &nbsp; Agregar Curso</a>
								</li>*/}
								<li>
									<a href="/Secretariacursoslista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Cursos</a>
								</li>
								<li> 
									<a href="/Secretariacursobuscar"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Curso</a>
								</li>
							</ul>
						</li>
						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-pallet fa-fw"></i> &nbsp; Materias <i className="fas fa-chevron-down"></i></a>
							<ul>
								{/*<li>
									<a href="materia-nueva.html"><i className="fas fa-plus fa-fw"></i> &nbsp; Agregar Materias</a>
								</li>*/}
								<li>
									<a href="/Secretariamaterialista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Materias</a>
								</li>
								
							</ul>
						</li>

						

						<li>
							<a href="/Secretariareclamos"><i className="fas fa-exclamation-circle fa-fw"></i> &nbsp; Reclamos</a>
						</li>
					</ul>
				</nav>
			</div>
		</section>

		
		<section className="full-box page-content">
			<nav className="full-box navbar-info">
				<a href="#" className="float-left show-nav-lateral">
					<i className="fas fa-exchange-alt"></i>
				</a>
				<a href="/Secretariaactualizar">
					<i className="fas fa-user-cog"></i>
				</a>
				<a href="#" className="btn-exit-system">
					<i className="fas fa-power-off"></i>
				</a>
			</nav>


            
            <div className="full-box page-header">
                <h3 className="text-left">
                    <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE CURSOS
                </h3>
                <p className="text-justify">
                    
                </p>
            </div>
            <div className="container-fluid">
                <ul className="full-box list-unstyled page-nav-tabs">
                    <li>
                      <div
                        onClick={() => openModal(1)}
                        data-toggle="modal"
                        data-target="#modalcursos" // Corregido el target
                    >
                        <a ><i className="fas fa-plus fa-fw"></i>&nbsp;  Añadir Curso nuevo</a>
                    </div>
                    </li>
                   
                    <li>
                        <a className="active" href="curso-lista.html"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE CURSOS</a>
                    </li>
                    <li>
                        <a style={{color: 'black'}} href="/Secretariacursobuscar"><i className="fas fa-search fa-fw"></i> &nbsp; BUSCAR CURSO</a>
                    </li>
                    
                </ul>
            </div>
            
            
            
            
			 <div className="container-fluid">
			 <div className="table-responsive">
					
					<table className="table table-dark table-sm">
						<thead>
							<tr className="text-center roboto-medium">
								<th>#</th>
								<th>ID</th>
								<th>CURSOS</th>
								<th>DOCENTE</th>
								<th>ACTUALIZAR/ELIMINAR</th>
								 
							</tr>
						</thead>
						<tbody className="table-group-divider">
						{cursos.map((cursos, i) => ( 
    <tr className="text-center" key={cursos.cursosId}> 
        <td>{i+1}</td>
        <td>{cursos.cursoId}</td>
        <td>{cursos.cursoSeleccionado}</td>
        <td>{cursos.profesorasignado}</td>
        <td>
								<button onClick={() => openModal(2, cursos)} className="btn btn-success" data-toggle='modal' data-target='#modalcursos'>
                          <i className="fas fa-edit"></i>
                        </button>
									 / &nbsp;
									<button onClick={() => deletecurso(Docente.DocenteId, Docente.nombre, Docente.numeroTelefono, Docente.cursosAsignados, Docente.numeroIdentificacion)} className="btn btn-danger">
                  <i className="far fa-trash-alt"></i>
                        </button>


								</td>
    </tr>
))}


							
						</tbody>
					</table>
				</div>
				<nav aria-label="Page navigation example">
					<ul className="pagination justify-content-center">
						<li className="page-item disabled">
							<a className="page-link" href="#" tabIndex="-1">Previous</a>
						</li>
						<li className="page-item"><a className="page-link" href="#">1</a></li>
						<li className="page-item"><a className="page-link" href="#">2</a></li>
						<li className="page-item"><a className="page-link" href="#">3</a></li>
						<li className="page-item">
							<a className="page-link" href="#">Next</a>
						</li>
					</ul>
				</nav>
			</div>
        </section>
    </main>
    
	<div id="modalcursos" className="modal fade" aria-hidden="true">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <label className="h5">{title}</label>
              <button type="button" className="fas fa-times" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div className="modal-body">
              <input type="hidden" id="candidatoEstudianteId" />
              <div className="input-group mb-3">
                
                
              </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-book-open"></i></span>
                    <input
                        type="text"
                        id="Curso"
                        className="form-control"
                        placeholder="CURSO"
                        value={cursoSeleccionado} 
                        onChange={(e) => setCursoSeleccionado(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-code-branch"></i></span>
                    <input
                        type="text"
                        id="codigo"
                        className="form-control"
                        placeholder="Codigo Curso"
                        value={codigo} 
                        onChange={(e) => setCodigo(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="far fa-newspaper"></i></span>
                    <input
                        type="text"
                        id="cursodescripcion"
                        className="form-control"
                        placeholder="Descripcion del curso"
                        value={description} 
                        onChange={(e) => setdescripcion(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-school"></i></span>
                    <input
                        type="text"
                        id="departementoacademico"
                        className="form-control"
                        placeholder="Departamento Academico"
                        value={departamentoacademico} 
                        onChange={(e) => setdepartamentoacademico(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                      <span className="input-group-text"><i className="fas fa-chalkboard-teacher"></i></span>
                      <select
							className="form-control"
							name="item_estado"
							id="item_estado"
							value={profesorasignado}
							onChange={(e) => setprofesorasignado(e.target.value)}
						>
							<option value="" disabled>
								Seleccione el Docente
							</option>
							{Docente.length > 0 ? (
								Docente.map((docente) => (
									<option key={docente.DocenteId} value={docente.nombre}>
										{docente.nombre}
									</option>
								))
							) : (
								<option value="" disabled>
									Cargando Docentes...
								</option>
							)}
						</select>

		  
                    </div>
          
                    
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-person-booth"></i></span>
                    <input
                        type="text"
                        id="codigo"
                        className="form-control"
                        placeholder="Aulas Asignadas"
                        value={aulasAsignadas} 
                        onChange={(e) => setaulasAsignadas(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                            <div class="form-group">
                              <span className="input-group-text"><i className="far fa-calendar-alt center"></i>Selecciona la fecha limite: </span>
                            
                            
                            <input type="datetime-local" id="fecha" name="fecha" class="form-control" value={fechalimiteincripcion} onChange={(e)=>setfechalimiteincripcion(e.target.value)}/>
                          </div>
                        </div>
                        <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-chalkboard"></i></span>
                    <input
                        type="text"
                        id="codigo"
                        className="form-control"
                        placeholder="Metodos de enseñanza..."
                        value={metodosenseñanza}  
                        onChange={(e) => setmetodosenseñanza(e.target.value)}
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

			

        )


}