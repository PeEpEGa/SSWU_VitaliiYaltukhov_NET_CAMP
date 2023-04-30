// Формат дати мав бути трішки інший.
IPresenter presenter = new MainMenuPresenter();
while (presenter != null)
{
    presenter.Show();
    presenter = presenter.Action();
}
