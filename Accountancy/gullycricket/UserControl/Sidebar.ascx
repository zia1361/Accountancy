<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sidebar.ascx.cs" Inherits="gullycricket.UserControl.Sidebar" %>

  <!-- ======= Sidebar ======= -->
  <aside id="sidebar" class="sidebar">

    <ul class="sidebar-nav" id="sidebar-nav">

       <li class="nav-item">
        <a class="nav-link"  href="GeneralJournal">
          <i class="bi bi-diagram-3-fill"></i><span>General Journal</span>
        </a>
        
      </li><!-- End Generall Journal Nav -->

        <li class="nav-item">
        <a class="nav-link collapsed" data-bs-target="#match-nav" data-bs-toggle="collapse" href="#">
          <i class=" bi bi-card-text"></i><span>Financial Sheets</span><i class="bi bi-chevron-down ms-auto"></i>
        </a>
        <ul id="match-nav" class="nav-content collapse " data-bs-parent="#sidebar-nav">
          <li>
            <a href="CreateIncomeSheet.aspx">
              <i class="bi bi-circle"></i><span>Income</span>
            </a>
          </li>
             <li>
            <a href="CreateOwnersSheet.aspx">
              <i class="bi bi-circle"></i><span>Owners</span>
            </a>
          </li>
            <li>
            <a href="CreateBalanceSheet.aspx">
              <i class="bi bi-circle"></i><span>Balance</span>
            </a>
          </li>
          
         
        </ul>
      </li><!-- End Statment Nav -->

    

     
       
     

    </ul>

  </aside><!-- End Sidebar-->
