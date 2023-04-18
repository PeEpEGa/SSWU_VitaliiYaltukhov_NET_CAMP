using task5._2_sigma_.Presenters.Interfaces;
using task5._2_sigma_.Presenters;

IPresenter presenter = new MainMenuPresenter();
while (presenter != null)
{
    presenter.Show();
    presenter = presenter.Action();
}
