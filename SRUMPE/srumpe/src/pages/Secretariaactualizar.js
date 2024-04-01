import React from 'react'
import { Link } from "react-router-dom";

export default function Secretariaactualizar() {
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
							<a href="#" className="nav-btn-submenu"><i className="fas fa-users fa-fw"></i> &nbsp;  Acudiente <i className="fas fa-chevron-down"></i></a>
							<ul>
								<li>
									<a href="/Secretariaacudientelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Acudientes</a>
								</li>
								<li>
									<a href="/Secretariabuscaracudiente"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Acuendiente</a>
								</li>
							</ul>
						</li>
						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-chalkboard-user fa-fw"></i> &nbsp; Docentes <i className="fas fa-chevron-down"></i></a>
							<ul>
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
								
								<li>
									<a href="/Secretariamaterialista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Materias</a>
								</li>
								
							</ul>
						</li>
						<li>
							<a href=" " className="nav-btn-submenu"><i className="fas fa-kaaba"></i> &nbsp; Aulas <i className="fas fa-chevron-down"></i></a>
							<ul>
								
								<li>
									<a href="/Secretariaulalista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Aulas</a>
								</li>
							</ul>
						</li>
						<li>
							<a href=" " className="nav-btn-submenu"><i className="far fa-calendar-alt"></i> &nbsp; Horarios <i className="fas fa-chevron-down"></i></a>
							<ul>
								<li>
									<a href="/SecretariaHorarioslista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Horarios</a>
								</li>
								<li>
									<a href="/SecretariaHorariosbuscar"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Horario</a>
								</li>
							</ul>
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
					<i className="fas fa-sync-alt fa-fw"></i> &nbsp; ACTUALIZAR USUARIO
				</h3>
				<p className="text-justify">
					Lorem ipsum dolor sit amet, consectetur adipisicing elit. Suscipit nostrum rerum animi natus beatae ex. Culpa blanditiis tempore amet alias placeat, obcaecati quaerat ullam, sunt est, odio aut veniam ratione.
				</p>
			</div>
			<div className="container-fluid">
				<form action="" className="form-neon" autoComplete="off">
					<fieldset>
						<legend><i className="far fa-address-card"></i> &nbsp; Información personal</legend>
						<p><span className="badge badge-info">Administrativo</span> Permisos para registrar, actualizar y eliminar</p>
									<p><span className="badge badge-success">Docente</span> Permisos para registrar y actualizar</p>
									<p><span className="badge badge-dark">Estudiante</span> Solo permisos para visualizar</p>
						<div className="container-fluid">
							<div className="row">
								<div className="col-12 col-md-4">
									<div className="form-group">
										<label htmlFor="usuario_dni" className="frome bmd-label-floating">T.I/C.C</label>
										<input type="text" pattern="[0-9-]{1,20}" className="form-control" name="usuario_dni" id="usuario_dni" maxLength="20"/>
									</div>
								</div>
								
								<div className="col-12 col-md-4">
									<div className="form-group">
										<label htmlFor="usuario_nombre" className="frome bmd-label-floating">Nombres</label>
										<input type="text" pattern="[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{1,35}" className="form-control" name="usuario_nombre" id="usuario_nombre" maxLength="35"/>
									</div>
								</div>
								<div className="col-12 col-md-4">
									<div className="form-group">
										<label htmlFor="usuario_apellido" className="frome bmd-label-floating">Apellidos</label>
										<input type="text" pattern="[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{1,35}" className="form-control" name="usuario_apellido" id="usuario_apellido" maxLength="35"/>
									</div>
								</div>
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="usuario_telefono" className="frome bmd-label-floating">Teléfono</label>
										<input type="text" pattern="[0-9()+]{1,20}" className="form-control" name="usuario_telefono" id="usuario_telefono" maxLength="20"/>
									</div>
								</div>
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="usuario_direccion" className="frome bmd-label-floating">Dirección</label>
										<input type="text" pattern="[a-zA-Z0-99áéíóúÁÉÍÓÚñÑ()# ]{1,190}" className="form-control" name="usuario_direccion" id="usuario_direccion" maxLength="190"/>
									</div>
								</div>
								<div className="col-12 col-md-4">
									<div className="form-group">
										<label htmlFor="prestamo_fecha_final" className="frome ">Fecha de Nacimiento</label>
										<input type="date" className="form-control" name="prestamo_fecha_final" id="prestamo_fecha_final"/>
									</div>
								</div>
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="item_estado" className="frome bmd-label-floating">Genero</label>
										<select className="form-control" name="item_estado" id="item_estado">
											<option value="" selected="" disabled="">Seleccione una Genero</option>
											<option selected="" value="femenino">Femenino</option>
											<option value="maculino">Masculino</option>
                                            <option value="otro">Otro</option>
										</select>
									</div>
								</div>
							</div>
						</div>
					</fieldset>
					<br/><br/><br/>
					<fieldset>
						<legend><i className="fas fa-user-lock"></i> &nbsp; Información de la cuenta</legend>
						<div className="container-fluid">
							<div className="row">
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="usuario_usuario" className="frome bmd-label-floating">Nombre de usuario</label>
										<input type="text" pattern="[a-zA-Z0-9]{1,35}" className="form-control" name="usuario_usuario" id="usuario_usuario" maxLength="35"/>
									</div>
								</div>
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="usuario_email" className="frome bmd-label-floating">Email</label>
										<input type="email" className="form-control" name="usuario_email" id="usuario_email" maxLength="70"/>
									</div>
								</div>
								<div className="col-12">
									<legend style={{marginTop: "40px"}}><i className="fas fa-lock"></i> &nbsp; Nueva contraseña</legend>
									<p>Para actualizar la contraseña de esta cuenta ingrese una nueva y vuelva a escribirla. En caso que no desee actualizarla debe dejar vacíos los dos campos de las contraseñas.</p>
								</div>
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="usuario_clave_nueva_1" className="frome bmd-label-floating">Contraseña</label>
										<input type="password" className="form-control" name="usuario_clave_nueva_1" id="usuario_clave_nueva_1" maxLength="200"/>
									</div>
								</div>
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="usuario_clave_nueva_2" className="frome bmd-label-floating">Repetir contraseña</label>
										<input type="password" className="form-control" name="usuario_clave_nueva_2" id="usuario_clave_nueva_2" maxLength="200"/>
									</div>
								</div>
							</div>
						</div>
					</fieldset>
					<fieldset>
						<p className="text-left">  -Para poder guardar los cambios en esta cuenta debe de ingresar su nombre de usuario y contraseña</p>
						<div className="container-fluid">
							<div className="row">
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="usuario_admin" className="frome bmd-label-floating">Nombre de usuario</label>
										<input type="text" pattern="[a-zA-Z0-9]{1,35}" className="form-control" name="usuario_admin" id="usuario_admin" maxLength="35"/>
									</div>
								</div>
								<div className="col-12 col-md-6">
									<div className="form-group">
										<label htmlFor="clave_admin" className="frome bmd-label-floating">Contraseña</label>
										<input type="password" className="form-control" name="clave_admin" id="clave_admin" maxLength="200"/>
									</div>
								</div>
							</div>
						</div>
					</fieldset>
					<p className="text-center" style={{marginTop: "40px"}}>
						<button type="submit" className="btn btn-raised btn-success btn-sm"><i className="fas fa-sync-alt"></i> &nbsp; ACTUALIZAR</button>
					</p>
				</form>
			</div>
		</section>
	</main>
    </React.Fragment>
    )
}