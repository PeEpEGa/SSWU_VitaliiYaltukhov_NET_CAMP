IPresenter presenter = new MainMenuPresenter();
while (presenter != null)
{
    presenter.Show();
    presenter = presenter.Action();
}