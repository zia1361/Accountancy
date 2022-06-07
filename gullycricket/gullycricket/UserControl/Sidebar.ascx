<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sidebar.ascx.cs" Inherits="gullycricket.UserControl.Sidebar" %>

  <!-- ======= Sidebar ======= -->
  <aside id="sidebar" class="sidebar">

    <ul class="sidebar-nav" id="sidebar-nav">

      <li class="nav-item">
        <a class="nav-link " href="javascript:void(0)">
          <i class="bi bi-grid"></i>
          <span>Dashboard</span>
        </a>
      </li><!-- End Dashboard Nav -->

      <li class="nav-item">
        <a class="nav-link collapsed" data-bs-target="#components-nav" data-bs-toggle="collapse" href="#">
          <i class="bi bi-menu-button-wide"></i><span>Tournament</span><i class="bi bi-chevron-down ms-auto"></i>
        </a>
        <ul id="components-nav" class="nav-content collapse " data-bs-parent="#sidebar-nav">
          <li>
            <a href="CreateTournament.aspx">
              <i class="bi bi-circle"></i><span>Create</span>
            </a>
          </li>
          <li>
            <a href="ViewAllTournaments.aspx">
              <i class="bi bi-circle"></i><span>Manage</span>
            </a>
          </li>
          
        </ul>
      </li><!-- End Tournament Nav -->

      <li class="nav-item">
        <a class="nav-link collapsed" data-bs-target="#forms-nav" data-bs-toggle="collapse" href="#">
          <i class="bi bi-people-fill"></i><span>Team</span><i class="bi bi-chevron-down ms-auto"></i>
        </a>
        <ul id="forms-nav" class="nav-content collapse " data-bs-parent="#sidebar-nav">
          <li>
            <a href="CreateTeam.aspx">
              <i class="bi bi-circle"></i><span>Create</span>
            </a>
          </li>
          <li>
            <a href="ViewAllTeams.aspx">
              <i class="bi bi-circle"></i><span>Manage</span>
            </a>
          </li>
         
        </ul>
      </li><!-- End Team Nav -->

      <li class="nav-item">
        <a class="nav-link collapsed" data-bs-target="#tables-nav" data-bs-toggle="collapse" href="#">
          <i class="bi bi-person-lines-fill"></i><span>Player</span><i class="bi bi-chevron-down ms-auto"></i>
        </a>
        <ul id="tables-nav" class="nav-content collapse " data-bs-parent="#sidebar-nav">
          <li>
            <a href="javascript:void(0)">
              <i class="bi bi-circle"></i><span>Add new Player</span>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <i class="bi bi-circle"></i><span>Manage</span>
            </a>
          </li>
        </ul>
      </li><!-- End Player Nav -->

     

     

    </ul>

  </aside><!-- End Sidebar-->
